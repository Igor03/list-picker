using System;
using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using FluentAssertions.Execution;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using JIgor.Projects.ListPicker.Exceptions;


namespace JIgor.Projects.ListPicker.UnitTests
{
    [TestClass]
    public class ListPickerExtensionsTests
    {
        [TestMethod]
        public void PickElements_1_ShouldReturnExpectedResult()
        {

            #region Arrange
            var sourceList = new List<string>()
            {
                "Breeze",
                "Brady",
                "Manning",
                "Brady"
            };
            var numberOfPicks = 2;
            var picker = new ListPicker();
            var sourceListInitialSize = sourceList.Count;
            #endregion

            #region Act
            var result = picker.PickElements(sourceList, numberOfPicks);
            #endregion

            #region Assert
            using var assertionScope = new AssertionScope();
            _ = result.Should().NotBeNull()
                .And.BeOfType(typeof(List<string>))
                .And.HaveCount(e => e == numberOfPicks);

            _ = sourceList.Should().NotBeNull()
                .And.BeOfType(typeof(List<string>))
                .And.HaveCount(e => e == (sourceListInitialSize - numberOfPicks));
            #endregion
        }

        [TestMethod]
        public void PickElements_1_ShouldThrowEmptyListException()
        {

            #region Arrange
            var sourceList = new List<string>() { };
            var numberOfPicks = 2;
            var picker = new ListPicker();
            #endregion

            #region Act
            Action result = () => _ = picker.PickElements(sourceList, numberOfPicks);
            #endregion

            #region Assert
            result.Should().ThrowExactly<EmptyListException>();
            #endregion
        }

        [TestMethod]
        public void PickElements_1_ShouldThrowInvalidNumberOfPicksException_1()
        {

            #region Arrange
            var sourceList = new List<string>()
            {
                "Breeze",
                "Montana",
                "Elway"
            };
            var numberOfPicks = 0;
            var picker = new ListPicker();
            #endregion

            #region Act
            Action result = () => _ = picker.PickElements(sourceList, numberOfPicks);
            #endregion

            #region Assert
            result.Should().ThrowExactly<InvalidNumberOfPicksException>(because: 
                "The number of picks was 0.");
            #endregion
        }

        [TestMethod]
        public void PickElements_1_ShouldThrowInvalidNumberOfPicksException_2()
        {

            #region Arrange
            var sourceList = new List<string>()
            {
                "Breeze",
                "Montana",
                "Elway"
            };
            var numberOfPicks = 4;
            var picker = new ListPicker();
            #endregion

            #region Act
            Action result = () => _ = picker.PickElements(sourceList, numberOfPicks);
            #endregion

            #region Assert

            result.Should().ThrowExactly<InvalidNumberOfPicksException>(because: 
                "The number of picks was greater than the total of elements of the source list.");

            #endregion
        }

        [TestMethod]
        public void PickElements_2_ShouldReturnExpectedResult()
        {

            #region Arrange
            var sourceList = new List<string>()
            {
                "Breeze",
                "Brady",
                "Manning",
                "Brady"
            };
            var numberOfPicks = 2;
            var picker = new ListPicker();
            var sourceListInitialSize = sourceList.Count;
            Func<string, bool> pickCondition = p => p == "Breeze";
            var matchedElementsCount = sourceList.Where(pickCondition).ToList().Count;
            #endregion

            #region Act
            var result = picker.PickElements(sourceList, numberOfPicks, pickCondition);
            #endregion

            #region Assert
            using var assertionScope = new AssertionScope();
            _ = result.Should().NotBeNull()
                .And.BeOfType(typeof(List<string>))
                .And.HaveCount(e => e == (numberOfPicks) || e == (matchedElementsCount));

            _ = sourceList.Should().NotBeNull()
                .And.BeOfType(typeof(List<string>))
                .And.HaveCount(e => e == (sourceListInitialSize - numberOfPicks) || e == (sourceListInitialSize - matchedElementsCount));
            #endregion
        }

        [TestMethod]
        public void PickElements_2_ShouldThrowEmptyListException()
        {

            #region Arrange
            var sourceList = new List<string>() { };
            var numberOfPicks = 2;
            var picker = new ListPicker();
            Func<string, bool> pickCondition = p => p == "Breeze";
            #endregion

            #region Act
            Action result = () => _ = picker.PickElements(sourceList, numberOfPicks, pickCondition);
            #endregion

            #region Assert
            _ = result.Should().ThrowExactly<EmptyListException>(because:
                "The source list has no elements");
            #endregion
        }

        [TestMethod]
        public void PickElements_2_ShouldThrowInvalidNumberOfPicksException_1()
        {

            #region Arrange
            var sourceList = new List<string>()
            {
                "Mahomes",
                "Wilson"
            };
            var numberOfPicks = 0;
            var picker = new ListPicker();
            Func<string, bool> pickCondition = p => p == "Breeze";
            #endregion

            #region Act
            Action result = () => _ = picker.PickElements(sourceList, numberOfPicks, pickCondition);
            #endregion

            #region Assert
            _ = result.Should().ThrowExactly<InvalidNumberOfPicksException>(because:
                "The number of picks was 0.");
            #endregion
        }

        [TestMethod]
        public void PickElements_2_ShouldThrowInvalidNumberOfPicksException_2()
        {

            #region Arrange
            var sourceList = new List<string>()
            {
                "Mahomes",
                "Wilson"
            };
            var numberOfPicks = 3;
            var picker = new ListPicker();
            Func<string, bool> pickCondition = p => p == "Breeze";
            #endregion

            #region Act
            Action result = () => _ = picker.PickElements(sourceList, numberOfPicks, pickCondition);
            #endregion

            #region Assert
            _ = result.Should().ThrowExactly<InvalidNumberOfPicksException>(because:
                "The number of picks was greater than the total of elements of the source list.");
            #endregion
        }
    }
}
