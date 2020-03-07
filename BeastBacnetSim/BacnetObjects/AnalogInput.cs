
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO.BACnet;

namespace BaCSharp
{
    public class AnalogInput<T> : AnalogObject<T>
    {
        public AnalogInput(int ObjId, String ObjName, String Description, T InitialValue, BacnetUnitsId Unit)
            : base(new BacnetObjectId(BacnetObjectTypes.OBJECT_ANALOG_INPUT, (uint)ObjId), ObjName, Description, InitialValue, Unit)
        {
            m_PRESENT_VALUE_ReadOnly = true;
        }
        public AnalogInput(BacnetObjectId ObjId, String ObjName, String Description, T InitialValue, BacnetUnitsId Unit)
            : base(ObjId, ObjName, Description, InitialValue, Unit)
        {
            m_PRESENT_VALUE_ReadOnly = true;
        }
        public AnalogInput() { }
    }
}
