
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO.BACnet;

namespace BaCSharp
{
    public class StructuredView : BaCSharpObject
    {
        protected List<BacnetValue> m_PROP_SUBORDINATE_LIST = new List<BacnetValue>();
        [BaCSharpType(BacnetApplicationTags.BACNET_APPLICATION_TAG_OBJECT_ID)]
        public virtual List<BacnetValue> PROP_SUBORDINATE_LIST
        {
            get { return m_PROP_SUBORDINATE_LIST; }
        }

        public StructuredView(int ObjId, String ObjName, String Description)
            : base(new BacnetObjectId(BacnetObjectTypes.OBJECT_STRUCTURED_VIEW, (uint)ObjId), ObjName,  Description)
        {
        }

        public StructuredView() { }

        public void AddBacnetObject(BaCSharpObject newObj)
        {
            m_PROP_SUBORDINATE_LIST.Add(new BacnetValue(BacnetApplicationTags.BACNET_APPLICATION_TAG_OBJECT_ID, newObj.PROP_OBJECT_IDENTIFIER));
            // Each object provided by the server must be added one by one to the DeviceObject
            Mydevice.AddBacnetObject(newObj);
        }
    }
}
