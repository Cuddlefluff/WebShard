﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using WebShard.Serialization;

namespace UnitTests.Serialization
{
    [TestFixture]
    public class JsonDeserializerTests
    {
        class Foo
        {
            
        }
        [TestCase(typeof(int), "10", 10)]
        [TestCase(typeof(byte), "10", (byte)10)]
        [TestCase(typeof(short), "-10", (short)-10)]
        [TestCase(typeof(Foo), "", null)]
        [TestCase(typeof(string), "\"Foo\"", "Foo")]
        [TestCase(typeof(string), "Foo", "Foo")]
        [TestCase(typeof(bool), "true", true)]
        [TestCase(typeof(bool), "false", false)]
        public void Deserialize_Primitives(Type deserializeType, string expression, object expectedResult)
        {
            // Arrange
            var json = new JsonDeserializer();

            // Act
            var result = json.Deserialize(expression, deserializeType);

            // Assert
            Assert.That(result, Is.EqualTo(expectedResult));
        }

        [Test]
        public void Deserialize_Array()
        {
            // Arrange
            var json = new JsonDeserializer();

            // Act
            var result = (int[])json.Deserialize("[1, 2, 3, 4]", typeof (int[]));

            // Assert
            Assert.That(result, Is.EquivalentTo(new [] { 1, 2, 3, 4}));
        }
    }
}
