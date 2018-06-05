using System;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using AssemblyControlledByOthers;
using AssemblyControlledByUs;
using Xunit;

namespace Testing
{
    public class PleaseProvideAGoodPracticeForInterfaceImpl
    {
        [Fact]
        [SuppressMessage("ReSharper", "RedundantCast")]
        public void should_apply_ploymorphism()
        {
            var budgerigar = new Budgerigar();
            int randomId = budgerigar.RandomId;
            string flyableFly = ((IFlyable)budgerigar).Fly();
            string parrotFly = ((IFlyable)(Parrot)budgerigar).Fly();
            string budgerigarFly = budgerigar.Fly();

            Assert.Equal($"Parrot({randomId}).Fly() -> Budgerigar.Fly()", flyableFly);
            Assert.Equal($"Parrot({randomId}).Fly() -> Budgerigar.Fly()", parrotFly);
            Assert.Equal($"Parrot({randomId}).Fly() -> Budgerigar.Fly()", budgerigarFly);
        }

        [Fact]
        public void should_keep_random_id_internal()
        {
            Type type = typeof(Parrot);
            PropertyInfo propertyInfo = type.GetProperty(
                "RandomId",
                BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.GetProperty);

            Assert.NotNull(propertyInfo);
            MethodInfo propertyInfoGetMethod = propertyInfo.GetMethod;
            Assert.True(propertyInfoGetMethod.IsAssembly);
            Assert.False(propertyInfoGetMethod.IsFamily);
        }

        [Fact]
        public void should_keep_explicite_impl_of_interface()
        {
            Type type = typeof(Parrot);
            InterfaceMapping interfaceMap = type.GetInterfaceMap(typeof(IFlyable));
            MethodInfo parrotFlyMethod = interfaceMap.TargetMethods.Single();
            
            Assert.Equal("AssemblyControlledByUs.IFlyable.Fly", parrotFlyMethod.Name);
            Assert.False(parrotFlyMethod.IsPublic);
        }

        [Fact]
        public void should_keep_assembly_visibility_mode()
        {
            Assembly assemblyControlledByOthers = typeof(Budgerigar).Assembly;
            Assembly assemblyControlledByUs = typeof(Parrot).Assembly;
            
            Assert.NotEqual(assemblyControlledByUs, assemblyControlledByOthers);
            var visibleSettings = (InternalsVisibleToAttribute) assemblyControlledByUs
                .GetCustomAttributes(typeof(InternalsVisibleToAttribute)).Single();

            Assert.Equal("Testing", visibleSettings.AssemblyName);
            Assert.Empty(assemblyControlledByOthers.GetCustomAttributes(typeof(InternalsVisibleToAttribute)));
        }

        [Fact]
        public void should_not_add_other_visible_methods_in_parrot()
        {
            Type type = typeof(Parrot);
            int notAllowedMethodNumber = type.GetMethods(
                    BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.DeclaredOnly | BindingFlags.Static |
                    BindingFlags.Instance)
                .Count(m => m.Name != "Fly" && m.Name != "get_RandomId" && m.Name != "AssemblyControlledByUs.IFlyable.Fly");

            Assert.Equal(0, notAllowedMethodNumber);
        }
    }
}
