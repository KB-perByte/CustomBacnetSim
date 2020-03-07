
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO.BACnet;

namespace BaCSharp
{
    public class BinaryInput : BinaryObject
    {
        public BinaryInput(int ObjId, String ObjName, String Description, bool InitialValue)
            : base(new BacnetObjectId(BacnetObjectTypes.OBJECT_BINARY_INPUT, (uint)ObjId), ObjName, Description, InitialValue)
        {
            m_PRESENT_VALUE_ReadOnly = true;
        }
        public BinaryInput() { }
    }
}
