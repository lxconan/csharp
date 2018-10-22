﻿using System;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using basic.Common;
using Xunit;

namespace basic
{
    public class VariablesAndParameters
    {
        [Fact]
        public void should_initialize_to_default_value()
        {
            var defaultValueDemo = new DefaultValueDemoClass();

            // change the variable values of the following 2 lines to correct values
            RefTypeClass expectedReferenceTypeValue = null;
            const int expectedValueTypeValue = 0;

            Assert.Equal(expectedReferenceTypeValue, defaultValueDemo.referenceTypeValue);
            Assert.Equal(expectedValueTypeValue, defaultValueDemo.valueTypeValue);
            Assert.Null(defaultValueDemo.stringValue);
           
        }

        #pragma warning disable xUnit2000
        
        [Fact]
        public void should_get_default_value_using_default_operator()
        {
            // change the variable values of the following 4 lines to correct values.
            const int expectedDefaultIntResult = 0;
            const bool expectedDefaultBoolResult = false;
            const char expectedDefaultCharResult = '\0';
            object expectedDefaultObjectResult = null;
            

            Assert.Equal(expectedDefaultIntResult, default(int));
            Assert.Equal(expectedDefaultBoolResult, default(bool));
            Assert.Equal(expectedDefaultCharResult, default(char));
            Assert.Equal(expectedDefaultObjectResult, default(object));
        }
        
        #pragma warning restore xUnit2000

        [Fact]
        public void should_get_copy_of_the_argument_when_passing_by_value_for_value_type()
        {
            int passingInt = 1;

            // change the variable value to correct one.
            const int expectedResult = 1;

            FunctionPassingIntAsArgument(passingInt);

            Assert.Equal(expectedResult, passingInt);
        }

        [Fact]
        public void should_get_copy_of_the_argument_when_passing_by_value_for_ref_type()
        {
            var refTypeObject = new RefTypeClass(1);
            RefTypeClass modifiedRefTypeObject = FunctionPassingRefTypeClassAsArgument(refTypeObject);

            // change the variable value to correct one.
            RefTypeClass expectedResult = refTypeObject;
            //???
            Assert.Same(expectedResult, refTypeObject);
        }

        [Fact]
        public void should_ref_to_same_location_when_passing_by_ref_for_value_type()
        {
            int passingInt = 1;

            // change the variable value to correct one.
            const int expectedResult = 2;

            FunctionPassingRefIntAsArgument(ref passingInt);

            Assert.Equal(expectedResult, passingInt);
        }

        [Fact]
        [SuppressMessage("ReSharper", "UnusedVariable")]
        public void should_ref_to_same_location_when_passing_by_ref_for_ref_type()
        {
            var refTypeObject = new RefTypeClass(1);
            RefTypeClass refToOriginalObject = refTypeObject;

            RefTypeClass modifiedRefTypeObject = FunctionPassingRefRefTypeClassAsArgument(
                ref refTypeObject);

            // change the variable value to correct one
            object expectedResult = refTypeObject;
            //???
            Assert.Same(expectedResult, refTypeObject);
        }

        [Fact]
        [SuppressMessage("ReSharper", "InlineOutVariableDeclaration")]
        public void should_ref_to_same_location_when_passing_by_out_for_value_type()
        {
            int passingInt;

            FunctionPassingOutIntAsArgument(out passingInt);

            // change the variable value to correct one
            const int expectedResult = 2;

            Assert.Equal(expectedResult, passingInt);
        }

        [Fact]
        [SuppressMessage("ReSharper", "InlineOutVariableDeclaration")]
        [SuppressMessage("ReSharper", "UnusedVariable")]
        public void should_ref_to_same_location_when_passing_by_out_for_ref_type()
        {
            RefTypeClass refTypeObject;

            RefTypeClass modifiedRefTypeObject =
                FunctionPassingOutRefTypeClassAsArgument(out refTypeObject);
            
            // change the variable value to correct one
            object expectedResult = refTypeObject;
            //???
            Assert.Equal(expectedResult, refTypeObject);
        }

        [Fact]
        public void should_pass_variable_length_parameter_as_array()
        {
            int sum = PassVariableLengthArguments(1, 2, 3, 4, 5);

            // change the variable value to correct one
            const int expectedResult = 15;

            Assert.Equal(expectedResult, sum);
        }

        [Fact]
        public void should_pass_as_optional_parameter()
        {
            int optionalParameterValue = PassAsOptionalArgument();

            // change the variable value to correct one
            const int expectedResult = 23;

            Assert.Equal(expectedResult, optionalParameterValue);
        }

        private static int PassAsOptionalArgument(int value = 23)
        {
            return value;
        }

        private static int PassVariableLengthArguments(params int[] values)
        {
            return values.Sum(i => i);
        }

        private static RefTypeClass FunctionPassingOutRefTypeClassAsArgument(
            out RefTypeClass refTypeObject)
        {
            refTypeObject = new RefTypeClass(1);
            return refTypeObject;
        }

        private static void FunctionPassingOutIntAsArgument(out int passingInt)
        {
            passingInt = 2;
        }

        [SuppressMessage("ReSharper", "RedundantAssignment")]
        private RefTypeClass FunctionPassingRefRefTypeClassAsArgument(
            ref RefTypeClass refTypeObject)
        {
            refTypeObject = new RefTypeClass(2);
            return refTypeObject;
        }

        private static void FunctionPassingRefIntAsArgument(ref int passingInt)
        {
            passingInt = passingInt * 2;
        }

        [SuppressMessage("ReSharper", "RedundantAssignment")]
        private static RefTypeClass FunctionPassingRefTypeClassAsArgument(
            RefTypeClass refTypeObject)
        {
            refTypeObject = new RefTypeClass(2);
            return refTypeObject;
        }

        [SuppressMessage("ReSharper", "RedundantAssignment")]
        private static void FunctionPassingIntAsArgument(int value)
        {
            value = value * 2;
        }
    }
}