using System;
using Xunit;
using System.Management.SExtension;

namespace Tests
{
    public class SysExtensionsTests
    {
        [Fact]
        public void TestTotalMemory()
        {
            var totalRam = Win32SESystemResources.TotalVisibleMemorySize;

            Assert.True(totalRam > 0);
        }

        [Fact]
        public void TestVirtMemory()
        {
            var totalVirtMem = Win32SESystemResources.TotalVirtualMemorySize;

            Assert.True(totalVirtMem > 0);
        }

        [Fact]
        public void TestFreeRam()
        {
            var totalFreeMem = Win32SESystemResources.GetFreePhysicalMemory();

            Assert.True(totalFreeMem > 0 && totalFreeMem < Win32SESystemResources.TotalVisibleMemorySize);
        }

        [Fact]
        public void TestFreeVirtMemory()
        {
            var freeVirtMem = Win32SESystemResources.GetFreeVirtualMemory();

            Assert.True(freeVirtMem < Win32SESystemResources.TotalVirtualMemorySize);
        }
    }
}
