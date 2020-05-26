using System;
using System.Runtime.InteropServices;

namespace DNSsniffer.WinDivert
{
    enum WINDIVERT_LAYER
    {
        WINDIVERT_LAYER_NETWORK = 0,
        WINDIVERT_LAYER_NETWORK_FORWARD,
        WINDIVERT_LAYER_FLOW,
        WINDIVERT_LAYER_SOCKET,
        WINDIVERT_LAYER_REFLECT,
    };
    enum WINDIVERT_FLAG
    {
        WINDIVERT_FLAG_SNIFF = 0x0001,
        WINDIVERT_FLAG_DROP = 0x0002,
        WINDIVERT_FLAG_RECV_ONLY = 0x0004,
        WINDIVERT_FLAG_READ_ONLY = WINDIVERT_FLAG_RECV_ONLY,
        WINDIVERT_FLAG_SEND_ONLY = 0x0008,
        WINDIVERT_FLAG_WRITE_ONLY = WINDIVERT_FLAG_SEND_ONLY,
        WINDIVERT_FLAG_NO_INSTALL = 0x0010,
        WINDIVERT_FLAG_FRAGMENTS = 0x0020
    };

    struct WINDIVERT_ADDRESS
    {
        public Int64 Timestamp;
        public byte Layer;
        public byte Event;
        public byte Flags;
        public byte Reserved1;
        public UInt32 Reserved2;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 64)]
        public byte[] union;
    };

    class WinDivert
    {
        UIntPtr handle;
        WINDIVERT_ADDRESS addr;

        [DllImport("WinDivert.dll", EntryPoint = "WinDivertOpen")]
        private extern static UIntPtr WinDivertOpen(string filter, WINDIVERT_LAYER layer,
            Int16 prio, WINDIVERT_FLAG flags);

        [DllImport("WinDivert.dll", EntryPoint = "WinDivertRecv")]
        private extern static bool WinDivertRecv(UIntPtr handle, byte[] packet,
            uint packetLen, ref uint pRecvLen, ref WINDIVERT_ADDRESS addr);

        [DllImport("WinDivert.dll", EntryPoint = "WinDivertSend")]
        private extern static bool WinDivertSend(UIntPtr handle, byte[] packet,
            uint packetLen, ref uint pSendLen, ref WINDIVERT_ADDRESS addr);

        [DllImport("WinDivert.dll", EntryPoint = "WinDivertClose")]
        private extern static bool WinDivertClose(UIntPtr handle);

        [DllImport("WinDivert.dll", EntryPoint = "WinDivertHelperCalcChecksums")]
        private extern static bool WinDivertHelperCalcChecksums(byte[] packet,
            uint packetLen, ref WINDIVERT_ADDRESS addr, UInt64 flags);

        public WinDivert(string filter)
        {
            handle = WinDivertOpen(filter, WINDIVERT_LAYER.WINDIVERT_LAYER_NETWORK,
                0, 0);
            if (handle == (UIntPtr)(-1))
            {
                Console.WriteLine("Handle Error");
            }
        }


        /// <summary>
        /// 捕获数据包
        /// </summary>
        /// <param name="packet"></param>
        public bool Read(byte[] packet, ref uint len)
        {
            return WinDivertRecv(handle, packet, 1500, ref len, ref addr);
        }

        /// <summary>
        /// 发送数据包，flag为真时将数据包的outbound设置为0
        /// </summary>
        /// <param name="packet"></param>
        /// <param name="flag"></param>
        public bool Write(byte[] packet, ref uint len, bool flag)
        {
            if (flag)
            {
                addr.Flags &= 0xf5;
            }
            WinDivertHelperCalcChecksums(packet, 1500, ref addr, 0);
            return WinDivertSend(handle, packet, 1500, ref len, ref addr);
        }
        ~WinDivert()
        {
            WinDivertClose(handle);
        }
    }
}
