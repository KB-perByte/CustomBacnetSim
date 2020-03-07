
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO.BACnet;

namespace BaCSharp
{
    public class CharacterString : BaCSharpObject
    {

        public BacnetBitString m_PROP_STATUS_FLAGS = new BacnetBitString();
        [BaCSharpType(BacnetApplicationTags.BACNET_APPLICATION_TAG_BIT_STRING)]
        public virtual BacnetBitString PROP_STATUS_FLAGS
        {
            get { return m_PROP_STATUS_FLAGS; }
        }

        public bool m_PRESENT_VALUE_ReadOnly = false;
        public String m_PROP_PRESENT_VALUE;

        public virtual String PROP_PRESENT_VALUE
        {
            get { return m_PROP_PRESENT_VALUE; }
            set
            {
                if (m_PRESENT_VALUE_ReadOnly == false)
                {
                    m_PROP_PRESENT_VALUE = value;
                    ExternalCOVManagement(BacnetPropertyIds.PROP_PRESENT_VALUE);
                }
                else
                    ErrorCode_PropertyWrite = ErrorCodes.WriteAccessDenied;
            }
        }

        // This property shows the same attribut as the previous, but without restriction
        // for internal usage, not for network callbacks
        public virtual String internal_PROP_PRESENT_VALUE
        {
            get { return m_PROP_PRESENT_VALUE; }
            set { m_PROP_PRESENT_VALUE = value; ExternalCOVManagement(BacnetPropertyIds.PROP_PRESENT_VALUE); }
        }

        public CharacterString(int ObjId, String ObjName, String Description, String InitialValue, bool ReadOnly)
            : base(new BacnetObjectId(BacnetObjectTypes.OBJECT_CHARACTERSTRING_VALUE,(uint)ObjId), ObjName,  Description)
        {
            m_PROP_STATUS_FLAGS.SetBit((byte)0, false);
            m_PROP_STATUS_FLAGS.SetBit((byte)1, false);
            m_PROP_STATUS_FLAGS.SetBit((byte)2, false);
            m_PROP_STATUS_FLAGS.SetBit((byte)3, false);

            m_PRESENT_VALUE_ReadOnly = ReadOnly;
            m_PROP_PRESENT_VALUE = InitialValue;
        }
        public CharacterString() { }
    }
}
