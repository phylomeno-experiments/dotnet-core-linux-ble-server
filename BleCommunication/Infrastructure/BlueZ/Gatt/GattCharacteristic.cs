﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BleServer.Infrastructure.BlueZ.Core;
using Tmds.DBus;

namespace BleServer.Infrastructure.BlueZ.Gatt
{
    public class GattCharacteristic : PropertiesBase<GattCharacteristic1Properties>, IGattCharacteristic1,
        IObjectManagerProperties
    {
        public IList<GattDescriptor> Descriptors { get; } = new List<GattDescriptor>();

        public GattCharacteristic(ObjectPath objectPath, GattCharacteristic1Properties properties) : base(objectPath,
            properties)
        {
        }

        public Task<byte[]> ReadValueAsync(IDictionary<string, object> options)
        {
            throw new NotImplementedException();
        }

        public Task WriteValueAsync(byte[] value, IDictionary<string, object> options)
        {
            throw new NotImplementedException();
        }

        public Task StartNotifyAsync()
        {
            throw new NotImplementedException();
        }

        public Task StopNotifyAsync()
        {
            throw new NotImplementedException();
        }

        public IDictionary<string, IDictionary<string, object>> GetProperties()
        {
            return new Dictionary<string, IDictionary<string, object>>
            {
                {
                    "org.bluez.GattCharacteristic1", new Dictionary<string, object>
                    {
                        {"Service", Properties.Service},
                        {"UUID", Properties.UUID},
                        {"Flags", Properties.Flags},
                        {"Descriptors", Descriptors.Select(d => d.ObjectPath).ToArray()}
                    }
                }
            };
        }

        public void AddDescriptor(GattDescriptor gattDescriptor)
        {
            Descriptors.Add(gattDescriptor);
        }
    }
}