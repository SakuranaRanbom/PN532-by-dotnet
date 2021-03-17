using System;
using System.Device.I2c;
using System.Threading;
using Iot.Device.Pn532;
using Iot.Device.Ft4222;
using System.Device.Spi;
using System.Text;
using Iot.Device.Pn532.ListPassive;

var i2csettings = new I2cConnectionSettings(1, Pn532.I2cDefaultAddress);
using I2cDevice i2CDevice = I2cDevice.Create(i2csettings);
using var pn532 = new Pn532(i2CDevice);

/*var hardwareSpiSettings = new SpiConnectionSettings(0, 0);

using SpiDevice spi = SpiDevice.Create(hardwareSpiSettings);
using var pn532 = new Pn532(spi);*/

while (true)
{
    Console.Clear();
    pn532.ReadGpio(out var p7i, out var p3i, out var mode);
    Console.WriteLine(p7i);
    Console.WriteLine(p3i);
    Console.WriteLine(mode);

    try
    {
        dotest();
    }
    catch (Exception e)
    {
        Console.WriteLine(e);
        throw;
    }
    
    
   // Span<byte> span = stackalloc byte[8];
    //pn532.ReadDataAsTarget(span);
    //foreach (var by in span)
    //{
     //   Console.WriteLine(by);
    //}

    /*foreach (DiagnoseMode VARIABLE in Enum.GetValues(typeof(DiagnoseMode)))
    {
        if (pn532.RunSelfTest(VARIABLE))
        {
            Console.WriteLine($"{VARIABLE} is Ok");
        }
    }*/
    //var num = pn532.InitAsTarget(0,)

    /*var devices = FtCommon.GetDevices();
    Console.WriteLine($"获取到 {devices.Count} 个FT4222设备元素");
    foreach (var device in devices)
    {
        Console.WriteLine($"描述：{device.Description}");
        Console.WriteLine($"标志：{device.Flags}");
        Console.WriteLine($"编号：{device.Id}");
        Console.WriteLine($"位置编号：{device.LocId}");
        Console.WriteLine($"系列号：{device.SerialNumber}");
        Console.WriteLine($"设备类型：{device.Type}");
    }

    var (chip, dll) = FtCommon.GetVersions();
    Console.WriteLine($"芯片版本：{chip}");
    Console.WriteLine($"Dll版本：{dll}");*/
    
    
    
    Thread.Sleep(10000);
}

void dotest()
{
    
    var result = pn532.ListPassiveTarget(MaxTarget.One, TargetBaudRate.B106kbpsTypeA);
    if (result != null)
    {
        var oput =System.BitConverter.ToString(result);
        Console.WriteLine(oput);
    }
    
}