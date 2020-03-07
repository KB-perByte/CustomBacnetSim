

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO.BACnet;

namespace BaCSharp
{

    public class MultiStateInput : AnalogInput<uint>
    {

        public uint m_PROP_NUMBER_OF_STATES;
        [BaCSharpType(BacnetApplicationTags.BACNET_APPLICATION_TAG_UNSIGNED_INT)]
        public virtual uint PROP_NUMBER_OF_STATES
        {
            get { return m_PROP_NUMBER_OF_STATES; }
        }

        public BacnetValue[] m_PROP_STATE_TEXT;
        [BaCSharpType(BacnetApplicationTags.BACNET_APPLICATION_TAG_OBJECT_ID)]
        public virtual BacnetValue[] PROP_STATE_TEXT
        {
            get { return m_PROP_STATE_TEXT; }
        }

        public MultiStateInput(int ObjId, String ObjName, String Description, uint StatesNumber, uint InitialValue, bool WithPriorityArray)
            : base(new BacnetObjectId(BacnetObjectTypes.OBJECT_MULTI_STATE_INPUT, (uint)ObjId), ObjName, Description, InitialValue, BacnetUnitsId.UNITS_DEGREES_PHASE)
        {
            // InitialValue must be within 1 and m_PROP_NUMBER_OF_STATES
            m_PROP_NUMBER_OF_STATES = StatesNumber;
            m_PROP_STATE_TEXT = new BacnetValue[StatesNumber];
        }
        public MultiStateInput() { }

        protected override uint BacnetMethodNametoId(String Name)
        {
            if (Name == "get_PROP_UNITS")   // Hide this property
                return (uint)((int)BacnetPropertyIds.MAX_BACNET_PROPERTY_ID );
            else
                return base.BacnetMethodNametoId(Name);
        }
    }
}
