using System;
using NUnit.Framework;

namespace PAT.Portable.Test.IoC
{
    public class ContainerTestBase
    {
        protected Container Container;

        [SetUp]
        public void BeforeEach()
        {
            Container = new Container();
        }

        [TearDown]
        public void AfterEach()
        {
            Container = null;
        }
    }

    [TestFixture]
    public class Container_GetInstance : ContainerTestBase
    {
        [Test]
        public void CreatesAnInstanceWithNoParams()
        {
            var subject = (A)Container.GetInstance(typeof(A));
            Assert.IsInstanceOf<A>(subject);
        }

        [Test]
        public void CreatesAnInstanceWithParams()
        {
            var subject = (B)Container.GetInstance(typeof(B));
            Assert.IsInstanceOf<A>(subject.A);
        }

        [Test]
        public void ItAllowsAParameterlessConstructor()
        {
            var subject = (C)Container.GetInstance(typeof(C));
            Assert.True(subject.Invoked);
        }

        [Test]
        public void ItAllowsGenericInitialization()
        {
            var subject = Container.GetInstance<A>();
            Assert.IsInstanceOf<A>(subject);
        }

        class A
        { }

        class B
        {
            public A A { get; }

            public B()
            {
            }

            public B(A a)
            {
                A = a;
            }
        }

        class C
        {
            public bool? Invoked { get; set; }

            public C()
            {
                Invoked = true;
            }
        }
    }

    [TestFixture]
    public class Container_Register : ContainerTestBase
    {
        [Test]
        public void RegisterATypeFromAnInterface()
        {
            Container.Register<IAnimal, Cat>();
            var subject = Container.GetInstance<IAnimal>();
            Assert.IsInstanceOf<Cat>(subject);
        }

        [Test]
        public void InitializeObjectWithDependencies()
        {
            Container.Register<IAnimal, Sprollie>();
            var subject = (Sprollie)Container.GetInstance<IAnimal>();
            Assert.IsInstanceOf<Cat>(subject.Animal);
        }

        interface IAnimal
        {
            int Weight { get; }
        }

        class Cat : IAnimal
        {
            public int Weight => 42;
        }

        class Dog : IAnimal
        {
            public int Weight => 84;
        }

        class Sprollie : IAnimal
        {
            public int Weight => 100;
            public IAnimal Animal { get; } = null;

            public Sprollie(Cat cat)
            {
                Animal = cat;
            }
        }
    }

    [TestFixture]
    public class Container_RegisterSingleton : ContainerTestBase
    {
        [Test]
        public void ItReturnsASingleInstance()
        {
            var animal = new Animal();
            Container.RegisterSingleton(animal);
            var subject = Container.GetInstance<Animal>();
            Assert.IsInstanceOf<Animal>(subject);
        }

        class Animal
        { }
    }
}
