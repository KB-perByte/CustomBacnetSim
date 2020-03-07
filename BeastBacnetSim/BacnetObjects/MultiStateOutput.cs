
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO.BACnet;

namespace BaCSharp
{
   
    public class MultiStateOutput : MultiStateValueAndOutput
    {
        public MultiStateOutput(int ObjId, String ObjName, String Description, uint InitialValue, uint StatesNumber)
            : base(new BacnetObjectId(BacnetObjectTypes.OBJECT_MULTI_STATE_OUTPUT, (uint)ObjId), ObjName, Description, InitialValue, StatesNumber, true)
        {
        }

        public MultiStateOutput() { }
    }

    [Serializable]
    public class MultiStateValue : MultiStateValueAndOutput
    {
        public MultiStateValue(int ObjId, String ObjName, String Description, uint InitialValue, uint StatesNumber, bool WithPriorityArray)
            : base(new BacnetObjectId(BacnetObjectTypes.OBJECT_MULTI_STATE_VALUE, (uint)ObjId), ObjName, Description, InitialValue, StatesNumber, WithPriorityArray)
        {
        }

        public MultiStateValue() { }
    }

    // Could be used for MultiStateOutput
    // and MultiStateValue
    [Serializable]
    public abstract class MultiStateValueAndOutput:AnalogValueAndOutput<uint>
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

        public MultiStateValueAndOutput(BacnetObjectId ObjId, String ObjName, String Description, uint InitialValue, uint StatesNumber, bool WithPriorityArray)
            : base(ObjId, ObjName, Description, InitialValue, BacnetUnitsId.UNITS_DEGREES_PHASE, true)
        {
            // InitialValue must be within 1 and m_PROP_NUMBER_OF_STATES
            m_PROP_NUMBER_OF_STATES = StatesNumber;
            m_PROP_STATE_TEXT = new BacnetValue[StatesNumber];           
        }

        public MultiStateValueAndOutput() { }

        protected override uint BacnetMethodNametoId(String Name)
        {
            if (Name == "get_PROP_UNITS")   // Hide this property
                return (uint)((int)BacnetPropertyIds.MAX_BACNET_PROPERTY_ID );
            else
                return base.BacnetMethodNametoId(Name);
        }

        // Only check the value range, work is after done by the overrided method
        public override void set2_PROP_PRESENT_VALUE(IList<BacnetValue> Value, byte WritePriority)
        {
            uint newVal = (uint)Value[0].Value;

            if ((newVal > 0) && (newVal <= m_PROP_NUMBER_OF_STATES))
                base.set2_PROP_PRESENT_VALUE(Value, WritePriority);
            else
                ErrorCode_PropertyWrite=ErrorCodes.OutOfRange;
        }
    }
}
