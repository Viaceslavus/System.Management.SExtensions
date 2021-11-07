using System;
using System.Management;

namespace System.Management.SExtension
{
    /// <summary>
    /// A static class with a bunch of methods for retrieving system RAM information.
    /// </summary>
    public static class Win32SESystemResources
    {
        private static ManagementBaseObject GetSysData()
        {
            ObjectQuery wql = new ObjectQuery("SELECT * FROM Win32_OperatingSystem");
            ManagementObjectSearcher searcher = new ManagementObjectSearcher(wql);
            var enumerator = searcher.Get().GetEnumerator();
            enumerator.MoveNext();
            return enumerator.Current;
        }

        private static uint? _cachedTotalVisibleMemorySize = null;

        /// <summary>
        /// The total amount of physical memory available to the operating system is kilobytes.
        /// </summary>
        public static uint TotalVisibleMemorySize
        {
            get
            {
                if(_cachedTotalVisibleMemorySize == null)
                {
                    _cachedTotalVisibleMemorySize = Convert.ToUInt32(GetSysData()["TotalVisibleMemorySize"]);
                }
                return (uint)_cachedTotalVisibleMemorySize;
            }
        }


        private static uint? _cachedTotalVirtualMemorySize = null;

        /// <summary>
        /// Amount of virtual memory in kilobytes
        /// </summary>
        public static uint TotalVirtualMemorySize
        {
            get
            {
                if(_cachedTotalVirtualMemorySize == null)
                {
                    _cachedTotalVirtualMemorySize = Convert.ToUInt32(GetSysData()["TotalVirtualMemorySize"]);
                }
                return (uint)_cachedTotalVirtualMemorySize;
            }
        }

        /// <summary>
        /// Number of physical memory currently unused and available in kilobytes.
        /// </summary>
        public static uint GetFreePhysicalMemory()
        {
            return Convert.ToUInt32(GetSysData()["FreePhysicalMemory"]);
        }

        /// <summary>
        /// Number of virtual  memory currently unused and available in kilobytes.
        /// </summary>
        public static uint GetFreeVirtualMemory()
        {
            return Convert.ToUInt32(GetSysData()["FreePhysicalMemory"]);
        }
    }
}
