using System;

namespace NbitcOinWagerrPlay2
{
    public class ObjectHelper<T>
    {
        public static bool CompareModels(string /*PeopleResponseModel*/ expModel, string /*PeopleResponseModel*/ model)
        {
            bool expectedPropertiesExist = true;
            bool actualPropertiesExist = true;
            bool propertiesFormatEquils = true;
            foreach (var prop in expModel.GetType().GetProperties())
            {
                if (model.GetType().GetProperty(prop.Name) == null)
                {
                    actualPropertiesExist = false;
                    Console.WriteLine($"Property {prop.Name} doesn't exist in actual model");
                    break;
                }
                if (model.GetType().GetProperty(prop.Name).PropertyType != prop.PropertyType)
                {
                    propertiesFormatEquils = false;
                    Console.WriteLine($"Expected Property type is {prop.PropertyType}, but was - {model.GetType().GetProperty(prop.Name).PropertyType}");
                }
            }
            foreach (var prop in model.GetType().GetProperties())
            {
                if (expModel.GetType().GetProperty(prop.Name) == null)
                {
                    expectedPropertiesExist = false;
                    Console.WriteLine($"Property {prop.Name} doesn't exist in expected model");
                }
            }

            return expectedPropertiesExist && actualPropertiesExist && propertiesFormatEquils;
        }

        public static bool CompareModelsGeneric(T expModel, T model)
        {
            bool vlozhenost = false;
            bool expectedPropertiesExist = true;
            bool actualPropertiesExist = true;
            bool propertiesFormatEquils = true;
            foreach (var prop in expModel.GetType().GetProperties())
            {
                if (prop.GetType().GetProperties() != null)
                {
                    vlozhenost = true;
                    var propert = prop.GetType().GetProperties();
                }
                if (model.GetType().GetProperty(prop.Name) == null)
                {
                    actualPropertiesExist = false;
                    Console.WriteLine($"Property {prop.Name} doesn't exist in actual model");
                    break;
                }
                if (model.GetType().GetProperty(prop.Name).PropertyType != prop.PropertyType)
                {
                    propertiesFormatEquils = false;
                    Console.WriteLine($"Expected Property type is {prop.PropertyType}, but was - {model.GetType().GetProperty(prop.Name).PropertyType}");
                }
            }
            foreach (var prop in model.GetType().GetProperties())
            {
                if (expModel.GetType().GetProperty(prop.Name) == null)
                {
                    expectedPropertiesExist = false;
                    Console.WriteLine($"Property {prop.Name} doesn't exist in expected model");
                }
            }

            return expectedPropertiesExist && actualPropertiesExist && propertiesFormatEquils;
        }
    }
}