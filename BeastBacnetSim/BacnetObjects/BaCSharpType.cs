
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO.BACnet;

namespace BaCSharp
{
    class BaCSharpTypeAttribute : Attribute
    {
        public BacnetApplicationTags BacnetNativeType;

        public BaCSharpTypeAttribute(BacnetApplicationTags BacnetNativeType)
        {
            this.BacnetNativeType = BacnetNativeType;
        }
    }
}
