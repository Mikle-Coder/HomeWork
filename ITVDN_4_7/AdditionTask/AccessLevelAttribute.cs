//Создайте пользовательский атрибут AccessLevelAttribute, позволяющий определить
//уровень доступа пользователя к системе. Сформируйте состав сотрудников некоторой фирмы
//в виде набора классов, например, Manager, Programmer, Director. При помощи атрибута
//AccessLevelAttribute распределите уровни доступа персонала и отобразите на экране
//реакцию системы на попытку каждого сотрудника получить доступ в защищенную секцию.

[AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
public class AccessLevelAttribute : Attribute
{
    private readonly AccessLevelControl ascessLevel;
    public AccessLevelControl AccessLevel { get { return ascessLevel; } }
    public AccessLevelAttribute(AccessLevelControl ascessLevel)
	{
		this.ascessLevel = ascessLevel;
	}
    
    public enum AccessLevelControl
    {
        FullControl, MediumControl, LowControl
    }
}
