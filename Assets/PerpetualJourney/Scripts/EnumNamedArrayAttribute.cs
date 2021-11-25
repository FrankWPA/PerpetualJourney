 using UnityEngine;
 
namespace PerpetualJourney
{
    public class EnumNamedArrayAttribute : PropertyAttribute
    {
        public string[] Names;
        public EnumNamedArrayAttribute(System.Type namesEnumType)
        {
            this.Names = System.Enum.GetNames(namesEnumType);
        }
    }
}
