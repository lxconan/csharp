using System;
using System.Diagnostics.CodeAnalysis;
using System.Reflection;
using Xunit;

namespace edge
{
    public class ValueTuplesFacts
    {
        [Fact]
        [SuppressMessage("ReSharper", "UnusedVariable")]
        public void the_old_tuple_type_does_not_provide_semantic_meanings()
        {
            var student = new Tuple<string, short>("Harry", 1990);

            // Please complete the following statement to pass the test.
            string message = "";
            
            Assert.Equal("The student 'Harry' was born on 1990.", message);
        }

        #pragma warning disable CS0219
        [Fact]
        [SuppressMessage("ReSharper", "UnusedVariable")]
        public void the_value_tuple_could_be_deconstructed()
        {
            (string, int) student = ("Harry", 1990);
            
            // Please complete the following statement to pass the test, you should use `student`
            // variable in the following line.
            string message = "";
            
            Assert.Equal("The student 'Harry' was born on 1990.", message);
        }
        #pragma warning restore CS0219

        [Fact]
        [SuppressMessage("ReSharper", "UnusedVariable")]
        public void the_value_tuple_could_be_deconstructed_with_meaningful_variables()
        {
            (string name, int yearOfBirth) = ("Harry", 1990);
            
            // Please complete the following statement to pass the test.
            string message = "";
            
            Assert.Equal("The student 'Harry' was born on 1990.", message);
        }

        [Fact]
        public void guess_what_type_the__variable_is()
        {
            (string, int) student  = ("Harry", 1990);

            Type theType = student.GetType();
            
            // Please complete the following statement to pass the test. Note that you must directly
            // specify type using `typeof()` keyword
            Type expected = null;
            
            Assert.Equal(expected, theType);
        }

        #pragma warning disable CS0219
        
        [Fact]
        [SuppressMessage("ReSharper", "UnusedVariable")]
        public void the_value_tuple_could_also_be_accessed_as_if_they_has_property()
        {
            (string name, int yearOfBirth) student = ("Harry", 1990);
            
            // Please complete the following statement to pass the test. You should use `student`
            // anyway in the following statement.
            string message = "";
            
            Assert.Equal("The student 'Harry' was born on 1990.", message);
        }
        
        #pragma warning restore CS0219

        [Fact]
        public void the_value_tuple_does_not_contains_properties_as_you_think()
        {
            (string name, int yearOfBirth) student = ("Harry", 1990);

            Type typeOfStudent = student.GetType();
            FieldInfo nameField = typeOfStudent.GetField(
                "name", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
            PropertyInfo nameProperty = typeOfStudent.GetProperty(
                "name", 
                BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.GetProperty);
            FieldInfo itemField = typeOfStudent.GetField(
                "Item1", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
            PropertyInfo itemProperty = typeOfStudent.GetProperty(
                "Item1", 
                BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.GetProperty );

            // Please complete the following statements to pass the test. Note that you can only
            // write `true` or `false` and you cannot write any calculation expressions.
            const bool nameFieldExist = true;
            const bool namePropertyExist = true;
            const bool item1FieldExist = true;
            const bool item1PropertyExist = true;
            
            Assert.Equal(nameFieldExist, nameField != null);
            Assert.Equal(namePropertyExist, nameProperty != null);
            Assert.Equal(item1FieldExist, itemField != null);
            Assert.Equal(item1PropertyExist, itemProperty != null);
        }
    }
}