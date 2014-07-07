﻿/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 1/7/2014
 * Time: 5:35 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace UIAutomationTest.Helpers.ObjectModel
{
    using System;
    using MbUnit.Framework;using NUnit.Framework;
    using System.Management.Automation;
    
    /// <summary>
    /// Description of ISupportsTransformPatternTestFixture.
    /// </summary>
    // [MbUnit.Framework.Ignore][NUnit.Framework.Ignore]
    [MbUnit.Framework.TestFixture][NUnit.Framework.TestFixture]
    public class ISupportsTransformPatternTestFixture
    {
        [MbUnit.Framework.SetUp][NUnit.Framework.SetUp]
        public void SetUp()
        {
            MiddleLevelCode.PrepareRunspace();
        }
        
        [MbUnit.Framework.TearDown][NUnit.Framework.TearDown]
        public void TearDown()
        {
            MiddleLevelCode.DisposeRunspace();
        }
        
//        [MbUnit.Framework.Test][NUnit.Framework.Test]
//        public void Transform_ImplementsCommonPattern()
//        {
//            ISupportsInvokePattern invokableElement =
//                FakeFactory.GetAutomationElementForMethodsOfObjectModel(
//                    new IBasePattern[] { FakeFactory.GetTransformPattern(new PatternsData()) }) as ISupportsInvokePattern;
//            
//            Assert.IsNotNull(invokableElement as ISupportsInvokePattern);
//            
//            ISupportsHighlighter highlightableElement =
//                FakeFactory.GetAutomationElementForMethodsOfObjectModel(
//                    new IBasePattern[] { FakeFactory.GetTransformPattern(new PatternsData()) }) as ISupportsHighlighter;
//            
//            Assert.IsNotNull(highlightableElement as ISupportsHighlighter);
//            
//            ISupportsNavigation navigatableElement =
//                FakeFactory.GetAutomationElementForMethodsOfObjectModel(
//                    new IBasePattern[] { FakeFactory.GetTransformPattern(new PatternsData()) }) as ISupportsNavigation;
//            
//            Assert.IsNotNull(navigatableElement as ISupportsNavigation);
//            
//            ISupportsConversion conversibleElement =
//                FakeFactory.GetAutomationElementForMethodsOfObjectModel(
//                    new IBasePattern[] { FakeFactory.GetTransformPattern(new PatternsData()) }) as ISupportsConversion;
//            
//            Assert.IsNotNull(conversibleElement as ISupportsConversion);
//            
//            ISupportsRefresh refreshableElement =
//                FakeFactory.GetAutomationElementForMethodsOfObjectModel(
//                    new IBasePattern[] { FakeFactory.GetTransformPattern(new PatternsData()) }) as ISupportsRefresh;
//            
//            Assert.IsNotNull(refreshableElement as ISupportsRefresh);
//        }
//        
//        [MbUnit.Framework.Test][NUnit.Framework.Test]
//        public void Transform_ImplementsPatternInQuestion()
//        {
//            ISupportsTransformPattern element =
//                FakeFactory.GetAutomationElementForMethodsOfObjectModel(
//                    new IBasePattern[] { FakeFactory.GetTransformPattern(new PatternsData()) }) as ISupportsTransformPattern;
//            
//            Assert.IsNotNull(element as ISupportsTransformPattern);
//        }
//        
//        [MbUnit.Framework.Test][NUnit.Framework.Test]
//        public void Transform_DoesNotImplementOtherPatterns()
//        {
//            ISupportsValuePattern element =
//                FakeFactory.GetAutomationElementForMethodsOfObjectModel(
//                    new IBasePattern[] { FakeFactory.GetTransformPattern(new PatternsData()) }) as ISupportsValuePattern;
//            
//            Assert.IsNull(element as ISupportsValuePattern);
//        }
//        
////        [MbUnit.Framework.Test][NUnit.Framework.Test]
////        public void Transform_Move()
////        {
////            // Arrange
////            ISupportsTransformPattern element =
////                FakeFactory.GetAutomationElementForMethodsOfObjectModel(
////                    new IBasePattern[] { FakeFactory.GetTransformPattern(new PatternsData()) }) as ISupportsTransformPattern;
////            
////            // Act
////            // Assert
////            element.Move(1, 1);
////        }
////        
////        [MbUnit.Framework.Test][NUnit.Framework.Test]
////        public void Transform_Resize()
////        {
////            // Arrange
////            ISupportsTransformPattern element =
////                FakeFactory.GetAutomationElementForMethodsOfObjectModel(
////                    new IBasePattern[] { FakeFactory.GetTransformPattern(new PatternsData()) }) as ISupportsTransformPattern;
////            
////            // Act
////            // Assert
////            element.Resize(1, 1);
////        }
////        
////        [MbUnit.Framework.Test][NUnit.Framework.Test]
////        public void Transform_Rotate()
////        {
////            // Arrange
////            ISupportsTransformPattern element =
////                FakeFactory.GetAutomationElementForMethodsOfObjectModel(
////                    new IBasePattern[] { FakeFactory.GetTransformPattern(new PatternsData()) }) as ISupportsTransformPattern;
////            
////            // Act
////            // Assert
////            element.Rotate(1);
////        }
//        
//        [MbUnit.Framework.Test][NUnit.Framework.Test]
//        public void Transform_CanMove()
//        {
//            // Arrange
//            bool expectedValue = true;
//            ISupportsTransformPattern element =
//                FakeFactory.GetAutomationElementForMethodsOfObjectModel(
//                    new IBasePattern[] { FakeFactory.GetTransformPattern(new PatternsData() { TransformPattern_CanMove = expectedValue }) }) as ISupportsTransformPattern;
//            
//            // Act
//            
//            // Assert
//            Assert.AreEqual(expectedValue, element.CanMove);
//        }
//        
//        [MbUnit.Framework.Test][NUnit.Framework.Test]
//        public void Transform_CanResize()
//        {
//            // Arrange
//            bool expectedValue = false;
//            ISupportsTransformPattern element =
//                FakeFactory.GetAutomationElementForMethodsOfObjectModel(
//                    new IBasePattern[] { FakeFactory.GetTransformPattern(new PatternsData() { TransformPattern_CanResize = expectedValue }) }) as ISupportsTransformPattern;
//            
//            // Act
//            
//            // Assert
//            Assert.AreEqual(expectedValue, element.CanResize);
//        }
//        
//        [MbUnit.Framework.Test][NUnit.Framework.Test]
//        public void Transform_CanRotate()
//        {
//            // Arrange
//            bool expectedValue = true;
//            ISupportsTransformPattern element =
//                FakeFactory.GetAutomationElementForMethodsOfObjectModel(
//                    new IBasePattern[] { FakeFactory.GetTransformPattern(new PatternsData() { TransformPattern_CanRotate = expectedValue }) }) as ISupportsTransformPattern;
//            
//            // Act
//            
//            // Assert
//            Assert.AreEqual(expectedValue, element.CanRotate);
//        }
//        
//        [MbUnit.Framework.Test][NUnit.Framework.Test]
//        public void Transform_Move()
//        {
//            // Arrange
//            bool expectedResult = true;
//            bool result = false;
//            ISupportsTransformPattern element =
//                FakeFactory.GetAutomationElementForMethodsOfObjectModel(
//                    new IBasePattern[] { FakeFactory.GetTransformPattern(new PatternsData()) }) as ISupportsTransformPattern;
//            
//            // Act
//            element.Move(1, 1);
//            try {
//                (element as IUiElement).GetCurrentPattern<ITransformPattern>(TransformPattern.Pattern).Received(1).Move(1, 1);
//                result = true;
//            }
//            catch {}
//            
//            // Assert
//            Assert.AreEqual(expectedResult, result);
//        }
//        
//        [MbUnit.Framework.Test][NUnit.Framework.Test]
//        public void Transform_Resize()
//        {
//            // Arrange
//            bool expectedResult = true;
//            bool result = false;
//            ISupportsTransformPattern element =
//                FakeFactory.GetAutomationElementForMethodsOfObjectModel(
//                    new IBasePattern[] { FakeFactory.GetTransformPattern(new PatternsData()) }) as ISupportsTransformPattern;
//            
//            // Act
//            element.Resize(1, 1);
//            try {
//                (element as IUiElement).GetCurrentPattern<ITransformPattern>(TransformPattern.Pattern).Received(1).Resize(1, 1);
//                result = true;
//            }
//            catch {}
//            
//            // Assert
//            Assert.AreEqual(expectedResult, result);
//        }
//        
//        [MbUnit.Framework.Test][NUnit.Framework.Test]
//        public void Transform_Rotate()
//        {
//            // Arrange
//            bool expectedResult = true;
//            bool result = false;
//            ISupportsTransformPattern element =
//                FakeFactory.GetAutomationElementForMethodsOfObjectModel(
//                    new IBasePattern[] { FakeFactory.GetTransformPattern(new PatternsData()) }) as ISupportsTransformPattern;
//            
//            // Act
//            element.Rotate(1);
//            try {
//                (element as IUiElement).GetCurrentPattern<ITransformPattern>(TransformPattern.Pattern).Received(1).Rotate(1);
//                result = true;
//            }
//            catch {}
//            
//            // Assert
//            Assert.AreEqual(expectedResult, result);
//        }
    }
}
