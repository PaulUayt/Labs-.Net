using NUnit.Framework;
using FluentAssertions;
using MyDictionary;
using System.Collections.Generic;
using System;
using Moq;

namespace Dictionary.Tests
{
    [TestFixture]
    public class MyDictionatyTests
    {
        public MyDictionary<int, string> dict;
        public Mock<IMyMock> mock = new Mock<IMyMock>();
        [SetUp]
        public void Setup()
        {
            dict = new MyDictionary<int, string>();
            dict.Add(1, "One");
            dict.Add(2, "Two");
            dict.Add(3, "Three");
            dict.Add(4, "Four");
            dict.Add(5, "Five");
        }

        [Test]
        public void Count_TakeCount_Count5()
        {
            //arrenge
            int count;
            int expected = 5;

            //act
            count = dict.Count;

            //assert
            count.Should().Be(expected);
        }

        [Test]
        public void Keys_TakeKeys_KeysInDict()
        {
            //arrenge
            ICollection<int> keys;
            int[] expected = {1,2,3,4,5};

            //act
            keys = dict.Keys;

            //assert
            keys.Should().BeEquivalentTo(expected);
        }

        [Test]
        public void Values_TakeValues_ValuesInDict()
        {
            //arrenge
            ICollection<string> values;
            string[] expected = { "One", "Two", "Three", "Four", "Five" };

            //act
            values = dict.Values;

            //assert
            values.Should().BeEquivalentTo(expected);
        }

        [Test]
        public void Index_GettingByIndexNotEmptyElement_GetElem()
        {
            //arrenge
            string element;
            string expected = "One";

            //act
            element = dict[1];

            //assert
            element.Should().Be(expected);
        }

        [Test]
        public void Index_GettingByIndexEmptyElement_GetEmptyElem()
        {
            //arrenge
            string element;
            string expected = null;

            //act
            element = dict[10];

            //assert
            element.Should().Be(expected);
        }

        [Test]
        public void Index_SettingByIndex_SetElem()
        {
            //arrenge
            string element;
            string expected = "Ten";

            //act
            dict[10] = "Ten";
            element = dict[10];

            //assert
            element.Should().Be(expected);
        }

        [Test]
        public void Capacity_GettingCapacity_GetCapacityDict()
        {
            //arrenge
            int element;
            int expected = 6;

            //act
            element = dict.Capacity;

            //assert
            element.Should().Be(expected);
        }

        [Test]
        public void Capacity_ExeptionTest_InvalidOperationException()
        {
            //arrenge
            Action myDict;

            //act
            myDict = () =>
            {
                dict.Capacity = 3;
            };

            //assert
            myDict.Should().Throw<InvalidOperationException>();
        }

        [Test]
        public void AddItem_TestExeptionIsReadOnly_NotSupportedException()
        {
            //arrenge
            Action myDict;

            //act
            myDict = () =>
            {
                dict.IsReadOnly = true;
                dict.Add(new KeyValuePair<int, string>(7, "Seven"));
            };

            //assert
            myDict.Should().Throw<NotSupportedException>();
        }

        [Test]
        public void AddItem_TestExeption_ArgumentNullException()
        {
            //arrenge
            MyDictionary<int?, string> dict = new MyDictionary<int?, string>();
            Action myDict;

            //act
            myDict = () =>
            {
                dict.Add(new KeyValuePair<int?, string>(null, "One"));
            };

            //assert
            myDict.Should().Throw<ArgumentNullException>();

        }

        [Test]
        public void AddItem_TestExeption_ArgumentExceptionByKey()
        {
            //arrenge
            Action myDict;

            //act
            myDict = () =>
            {
                dict.Add(new KeyValuePair<int, string>(1, "One"));
            };

            //assert
            myDict.Should().Throw<ArgumentException>();
        }

        [TestCase(0, "Zero")]
        [TestCase(45, "Addd")]
        [TestCase(33, null)]
        public void AddItem_AddInEmptyItem_AddingElem(int key, string val)
        {
            //arrenge
            int count1 = dict.Count;

            //act
            dict.Add(new KeyValuePair<int, string>(key, val));
            int count2 = dict.Count;

            //assert
            count1.Should().Be(count2 - 1);
        }

        [Test]
        public void AddItem_WhenItemIsNotEmpty_FindingEmptyItemRight()
        {
            //arrenge
            int count1 = dict.Count;

            //act
            dict.Add(new KeyValuePair<int, string>(101, "101"));
            int count2 = dict.Count;


            //assert
            count1.Should().Be(count2 - 1);
        }

        [Test]
        public void AddItem_WhenItemIsNotEmpty_FindingEmptyItemLeft()
        {
            //arrenge
            dict.Add(98, "98");
            dict.Add(99, "99");
            int count1 = dict.Count;
            
            //act
            dict.Add(new KeyValuePair<int, string>(198, "101"));
            int count2 = dict.Count;

            //assert
            count1.Should().Be(count2 - 1);
        }

        [TestCase(0, "Zero")]
        [TestCase(45, "Addd")]
        [TestCase(33, null)]
        public void AddKeyVal__AddInEmptyItem_AddingElem(int key, string val)
        {
            //arrenge
            int count1 = dict.Count;

            //act
            dict.Add(key,val);
            int count2 = dict.Count;

            //assert
            count1.Should().Be(count2 - 1);
        }

        [Test]
        public void Contains_DictContainItem_BeTrue()
        {
            //arrenge
            bool result;

            //act
            dict.Add(98, "One");
            result = dict.Contains(new KeyValuePair<int, string>(98, "One"));

            //assert
            result.Should().BeTrue();
        }

        [Test]
        public void Contains_DictContainItem_BeFalse()
        {
            //arrenge
            bool result;

            //act
            dict.Add(new KeyValuePair<int, string>(98, "One"));
            result = dict.Contains(new KeyValuePair<int, string>(99, "One"));

            //assert
            result.Should().BeFalse();
        }

        [Test]
        public void ContainsKey_DictContainItem_BeTrue()
        {
            //arrenge
            bool result;

            //act
            result = dict.ContainsKey(5);

            //assert
            result.Should().BeTrue();
        }

        [Test]
        public void ContainsKey_DictContainItem_BeFalse()
        {
            //arrenge
            bool result;

            //act
            result = dict.ContainsKey(7);

            //assert
            result.Should().BeFalse();
        }

        [Test]
        public void RemoveKey_TestExeptionIsReadOnly_NotSupportedException()
        {
            //arrenge
            Action myDict;

            //act
            myDict = () =>
            {
                dict.IsReadOnly = true;
                dict.Remove(7);
            };

            //assert
            myDict.Should().Throw<NotSupportedException>();
        }

        [Test]
        public void RemoveItem_RemovingNotEmptyItem_RemoveElem()
        {
            //arrenge
            dict.Add(99, "99");
            int count1 = dict.Count;

            //act
            bool remove = dict.Remove(new KeyValuePair<int, string>(99, "99"));
            int count2 = dict.Count;

            //assert
            count1.Should().Be(count2 + 1);
            remove.Should().BeTrue();
        }

        [Test]
        public void RemoveItem_RemovingEmptyItem_NotRemoveElem()
        {
            //arrenge
            bool remove;

            //act
            remove = dict.Remove(new KeyValuePair<int, string>(6, "One"));
            
            //assert
            remove.Should().BeFalse();
        }

        [Test]
        public void RemoveKey_TestExeptionContainsKey_ArgumentNullException()
        {
            //arrenge
            MyDictionary<int?, string> dict = new MyDictionary<int?, string>();
            Action myDict;

            //act
            myDict = () =>
            {
                dict.Remove(null);
            };

            //assert
            myDict.Should().Throw<ArgumentNullException>();
        }

        [Test]
        public void RemoveKey_RemovingNotEmptyItem_RemoveElem()
        {
            //arrenge
            int count1 = dict.Count;

            //act
            bool remove = dict.Remove(1);
            int count2 = dict.Count;

            //assert
            count1.Should().Be(count2 + 1);
            remove.Should().BeTrue();
        }

        [Test]
        public void RemoveKey_RemovingEmptyItem_NotRemoveElem()
        {
            //arrenge
            bool remove;

            //act
            remove = dict.Remove(6);

            //assert
            remove.Should().BeFalse();
        }

        [Test]
        public void GetIndexByKey_ElementWithThisKeyIsMiss_ReturnMinus1()
        {
            //arrenge
            int index;
            int expected = -1;

            //act
            index = dict.GetIndexByKey(6);

            //assert
            index.Should().Be(expected);
        }

        [Test]
        public void Clear_TestExeptionIsReadOnly_NotSupportedException()
        {
            //arrenge
            Action myDict;

            //act
            myDict = () =>
            {
                dict.IsReadOnly = true;
                dict.Clear();
            };

            //assert
            myDict.Should().Throw<NotSupportedException>();
        }

        [Test]
        public void Clear_DictClearing_ClearDict()
        {
            //arrenge
            int expected = 0;

            //act
            dict.Clear();
            int count = dict.Count;

            //assert
            count.Should().Be(expected);
        }

        [Test]
        public void CopyTo_TestExeption_ArgumentNullException()
        {
            //arrenge
            Action myDict;

            //act
            myDict = () =>
            {
                dict.CopyTo(null, 5);
            };

            //assert
            myDict.Should().Throw<ArgumentNullException>();
        }

        [TestCase(-4)]
        [TestCase(12)]
        public void CopyTo_TestExeption_ArgumentOutOfRangeException(int arrIndex)
        {
            //arrenge
            Action myDict;
            var arr = new KeyValuePair<int, string>[dict.Count * 2];

            //act
            myDict = () =>
            {
                dict.CopyTo(arr, arrIndex);
            };

            //assert
            myDict.Should().Throw<ArgumentOutOfRangeException>();
        }

        [Test]
        public void CopyTo_TestExeption_ArgumentException()
        {
            //arrenge
            Action myDict;
            var arr = new KeyValuePair<int, string>[dict.Count * 2];

            //act
            myDict = () =>
            {
                dict.CopyTo(arr, 8);
            };

            //assert
            myDict.Should().Throw<ArgumentException>();
        }

        [Test]
        public void CopyTo_CopyInArr_ElementsContainsInArr()
        {
            //arrenge
            var arr = new KeyValuePair<int, string>[dict.Count * 2];

            //act
            dict.CopyTo(arr, 4);

            //assert
            foreach(KeyValuePair<int, string> item in dict)
            {
                arr.Should().Contain(item);
            }
        }

        [Test]
        public void Search_SearchElementByKey_SuccessfulSearch()
        {
            //arrenge
            string value;

            //act                    

            //assert
            foreach(KeyValuePair<int, string> item in dict)
            {
                value = dict.Search(item.Key);
                value.Should().Be(item.Value);
            }
        }

        [Test]
        public void Search_SearchElementByKey_ElementMiss()
        {
            //arrenge
            string value;

            //act
            value = dict.Search(dict.Count * 3);

            //assert
            value.Should().Be(null);
        }

        [Test]
        public void TryGetValue_TestExeption_ArgumentNullException()
        {
            //arrenge
            MyDictionary<int?, string>  dict = new MyDictionary<int?, string>(7);
            dict.Add(1, "One");
            dict.Add(2, "Two");
            dict.Add(3, "Three");
            dict.Add(4, "Four");
            dict.Add(5, "Five");
            Action myDict;

            //act
            myDict = () =>
            {
                dict.TryGetValue(null, out string val);
            };

            //assert
            myDict.Should().Throw<ArgumentNullException>();
        }

        [Test]
        public void TryGetValue_GetValueByKey_ReturnVal()
        {
            //arrenge
            string excepted = "Five";
            bool b;

            //act
            b = dict.TryGetValue(5, out string val);

            //assert
            val.Should().Be(excepted);
            b.Should().BeTrue();
        }

        [Test]
        public void TryGetValue_KeysIsNotContains_ReturnFalse()
        {
            //arrenge
            bool b;

            //act
            b = dict.TryGetValue(6, out string val);

            //assert
            b.Should().BeFalse();
        }

        /*[Test]
        public void OnAdd_AddItem_CallEvent()
        {
            //arrenge
            dict.OnAdd += mock.Object.TestMethod;


            //act
            dict.Add(6, "Six");

            //assert
            mock.Verify(k => k.TestMethod((object)dict, null));
        }*/
        /*
        [Test]
        public void OnRemove_RemoveItem_CallEvent()
        {
            //arrenge
            dict.OnRemove += mock.Object.TestMethod;

            //act
            dict.Remove(3);

            //assert
            mock.Verify(k => k.TestMethod((object)dict, null));
        }

        [Test]
        public void OnClear_ClearDict_CallEvent()
        {
            //arrenge
            dict.OnClear += mock.Object.TestMethod;

            //act
            dict.Clear();

            //assert
            mock.Verify(k => k.TestMethod((object)dict, null));
        }*/
    }
}
