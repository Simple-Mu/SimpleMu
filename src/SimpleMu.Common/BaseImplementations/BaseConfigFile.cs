using System.Reflection;
using System.Text.Json;
using SimpleMu.Common.Interfaces;

namespace SimpleMu.Common.BaseImplementations;

public abstract class BaseConfigFile : BaseReloadableFile,  IConfigFile
{
    protected BaseConfigFile(string fileName) : base(fileName)
    {
    }

    public override void NotifyFileChanged()
    {
        UpdateValues();
        base.NotifyFileChanged();
    }

    public void UpdateValues()
    {
        if (string.IsNullOrEmpty(FileContent))
        {
            return;
        }
        
        var json = JsonDocument.Parse(FileContent);
        var properties = GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly);

        foreach (var property in properties)
        {
            var jsonProperty = json.RootElement.GetProperty(property.Name);

            switch (jsonProperty.ValueKind)
            {
                case JsonValueKind.Undefined:
                    property.SetValue(this, null);
                    break;
                case JsonValueKind.Object:
                    break;
                case JsonValueKind.Array:
                    break;
                case JsonValueKind.String:
                    var value = jsonProperty.GetRawText();
                    property.SetValue(this, value);
                    break;
                case JsonValueKind.Number:
                    switch (Type.GetTypeCode(property.PropertyType))
                    {
                        case TypeCode.Int32:
                            property.SetValue(this, jsonProperty.GetInt32());
                            break;
                        case TypeCode.Double:
                            property.SetValue(this, jsonProperty.GetDouble());
                            break;
                        case TypeCode.UInt32:
                            property.SetValue(this, jsonProperty.GetUInt32());
                            break;
                    }
                    break;
                case JsonValueKind.True:
                    property.SetValue(this, true);
                    break;
                case JsonValueKind.False:
                    property.SetValue(this, false);
                    break;
                case JsonValueKind.Null:
                    property.SetValue(this, null);
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
        
        NotifyFileUpdated();
    }
}