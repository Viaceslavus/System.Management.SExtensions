# Simple abstraction over ``System.Management`` namespace

### [Nuget Package](https://www.nuget.org/packages/SystemManagement.SlvExtensions/1.0.1)

### The package provides a simple way for retrieving system information in .NET app with just a few functions.
</br>

---

- ## Getting Started

Installing Nuget Package: 
```
Install-Package SystemManagement.SlvExtensions -Version 1.0.1
```

Importing namespace:
```csharp
using System.Management.SExtension;
```

All static methods are stored in ``Win32SESystemResources`` class.

Gets free physical memory:
```csharp
void Main()
{
    var freeRam = Win32SESystemResources.GetFreePhysicalMemory();
    Console.WriteLine(freeRam);
}
```
</br>

---

- ## Problems with .NET's ``System.Management`` package.

This package allows you to avoid writing code the way ``System.Management`` namespace suggests. 
For example, using ``System.Management`` package to get the same result as with the code above, you'd likely write something like this: 
```csharp
void Main()
{
    ObjectQuery wql = new ObjectQuery("SELECT * FROM Win32_OperatingSystem");
    ManagementObjectSearcher searcher = new ManagementObjectSearcher(wql);
    ManagementObjectCollection results = searcher.Get();

    foreach (ManagementObject result in results)
    {
        Console.WriteLine("result["FreePhysicalMemory"]);
    }
}
```

Looks ugly...
