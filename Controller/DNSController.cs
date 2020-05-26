using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace DNSsniffer.Controller
{
    enum DNS_TYPE
    {
        A = 1,
        NS = 2,
        CNAME = 5
    };

    enum DNS_CLASS
    {

    };
    class DNSController
    {
        private Dictionary<string, string> records; // domain => address
        private bool run; // run flag

        public DNSController()
        {
            records = new Dictionary<string, string>();
            run = true;
        }
        /// <summary>
        /// add a new domain record
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        public void AddRecord(string key, string value)
        {
            try
            {
                records.Add(key, value);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }

        }

        /// <summary>
        /// Delete a domain record
        /// </summary>
        /// <param name="key"></param>
        public void DelRecord(string key)
        {
            records.Remove(key);
        }

        /// <summary>
        /// return all domain record
        /// </summary>
        /// <returns></returns>
        public Dictionary<string, string> AllRecord()
        {
            return records;
        }
        /// <summary>
        /// Start DNS Service
        /// </summary>
        public void RunDNSService()
        {
            byte[] packet = new byte[1500];
            uint len = 0;
            string query;
            string filter = "outbound and !loopback and !ipv6 and udp.DstPort == 53";
            WinDivert.WinDivert device = new WinDivert.WinDivert(filter);
            while (run)
            {
                Array.Clear(packet, 0, 1500);
                if (!device.Read(packet, ref len))
                    continue;

                query = GetQueryDomain(packet);
                Console.WriteLine(query);
                if (records.ContainsKey(query)
                    && packet[len - 3] == 0x01
                    && packet[len - 1] == 0x01)
                {
                    GenResponse(packet, ref len, records[query]);
                    device.Write(packet, ref len, true);
                }
                else
                {
                    device.Write(packet, ref len, false);
                }
            }
        }

        /// <summary>
        /// Stop DNS service
        /// </summary>
        public void StopDNSService()
        {
            run = false;
        }

        /// <summary>
        /// get the query domain from ippacket
        /// </summary>
        /// <param name="packet"></param>
        /// <returns></returns>
        public string GetQueryDomain(byte[] packet)
        {
            string domain = "";
            for (int i = 40; packet[i] != 0;)
            {
                for (int j = 0, k = packet[i++]; j < k; j++, i++)
                {
                    domain += (char)packet[i];
                }
                domain += '.';
            }
            domain = domain.Remove(domain.Length - 1);
            return domain;
        }

        /// <summary>
        /// generate a dns response packet
        /// </summary>
        /// <param name="packet"></param>
        /// <param name="len"></param>
        /// <param name="value"></param>
        public void GenResponse(byte[] packet, ref uint len, string value)
        {
            // Swap Address
            byte[] ip = new byte[4];
            Array.Copy(packet, 12, ip, 0, 4);
            Array.Copy(packet, 16, packet, 12, 4);
            Array.Copy(ip, 0, packet, 16, 4);

            // Swap Port
            byte[] port = new byte[2];
            Array.Copy(packet, 20, port, 0, 2);
            Array.Copy(packet, 22, packet, 20, 2);
            Array.Copy(port, 0, packet, 22, 2);

            // opcode
            packet[30] = 0x80;

            // Answer RRS
            packet[35] = 0x01;

            byte[] response = {0xc0, 0x0c, 0x00, 0x01, 0x00,
                0x01, 0x00, 0x00, 0x00, 0x11, 0x00, 0x04,
                0x00, 0x00, 0x00, 0x00};

            // Total Length
            UInt16 ipLen = (UInt16)(packet[2] << 8 | packet[3]);
            ipLen += (UInt16)response.Length;
            packet[2] = (byte)(ipLen >> 8);
            packet[3] = (byte)(ipLen & 0xff);

            // UDP Length
            UInt16 udpLen = (UInt16)(packet[24] << 8 | packet[25]);
            udpLen += (UInt16)response.Length;
            packet[24] = (byte)(udpLen >> 8);
            packet[25] = (byte)(udpLen & 0xff);

            int i = response.Length - 4;
            foreach (var item in value.Split('.'))
            {
                response[i++] = byte.Parse(item);
            }

            Array.Copy(response, 0, packet, len, response.Length);
            len += (uint)response.Length;
        }
    }
}
