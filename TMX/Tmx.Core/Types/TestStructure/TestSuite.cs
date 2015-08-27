﻿/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 12/19/2012
 * Time: 2:46 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace Tmx.Interfaces
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    // using System.Management.Automation;
    using System.Xml.Serialization;
    using Core;
    using Remoting;
    using TestStructure;
    // using Tmx.Core;
    
    /// <summary>
    /// Description of TestSuite.
    /// </summary>
    public class TestSuite : ITestSuite
    {
        public TestSuite()
        {
            UniqueId = Guid.NewGuid();
            TestScenarios = new List<ITestScenario>();
            Statistics = new TestStat();
            // 20150805
            // this.enStatus = TestSuiteStatuses.NotTested;
            enStatus = TestStatuses.NotRun;
            Id = TestData.GetTestSuiteId();
            addDefaultPlatform();
            SetNow();
        }
        
        public TestSuite(string testSuiteName, string testSuiteId)
        {
            UniqueId = Guid.NewGuid();
            TestScenarios = new List<ITestScenario> ();
            Statistics = new TestStat();
            // 20150805
            // this.enStatus = TestSuiteStatuses.NotTested;
            enStatus = TestStatuses.NotRun;
            Name = testSuiteName;
            Id = testSuiteId != string.Empty ? testSuiteId : TestData.GetTestSuiteId();
            addDefaultPlatform();
            SetNow();
        }
        
        void addAutogeneratedTestScenario(string testSuiteId)
        {
            TestScenarios.Add(new TestScenario(TestData.Autogenerated, "1", testSuiteId));
        }
        
        void addDefaultPlatform()
        {
            if (TestData.TestPlatforms.All(tp => tp.Name != TestData.DefaultPlatformName))
                TestData.AddDefaultPlatform();
            PlatformId = TestData.GetDefaultPlatformId();
            PlatformUniqueId = TestData.GetDefaultPlatformUniqueId();
        }
        
        [XmlAttribute]
        public virtual Guid UniqueId { get; set; }
        [XmlAttribute]
        public string Name { get; set; }
        [XmlAttribute]
        public string Id { get; set; }
        [XmlElement("TestScenarios", typeof(ITestScenario))]
        public virtual List<ITestScenario> TestScenarios { get; set; }
        [XmlAttribute]
        public virtual string Description { get; set; }

        string _status;
        [XmlAttribute]
        public virtual string Status { get { return _status; } }
        // 20150805
        // TestSuiteStatuses _enStatus;
        TestStatuses _enStatus;
        [XmlAttribute]
        // 20150805
        // public TestSuiteStatuses enStatus        
        public TestStatuses enStatus
        { 
            get { return _enStatus; }
            set{
                _enStatus = value;

                switch (value) {
                    // 20150805
                    // case TestSuiteStatuses.Passed:
                    case TestStatuses.Passed:
                        _status = TestData.TestStatePassed;
                        break;
                    // 20150805
                    // case TestSuiteStatuses.Failed:
                    case TestStatuses.Failed:
                        _status = TestData.TestStateFailed;
                        break;
                    // 20150805
                    // case TestSuiteStatuses.NotTested:
                    case TestStatuses.NotRun:
                        _status = TestData.TestStateNotTested;
                        break;
                    // 20150805
                    // case TestSuiteStatuses.KnownIssue:
                    case TestStatuses.KnownIssue:
                        _status = TestData.TestStateKnownIssue;
                        break;
                    default:
                        throw new Exception(Tmx_Core_Resources.TestSuite_enStatus_Invalid_value_for_TestSuiteStatuses);
                }
            }
        }

        [XmlAttribute]
        public string Tag { get; set; }

        [XmlIgnore]
        public TestStat Statistics { get; set; }
        
        [XmlAttribute]
        public virtual DateTime Timestamp { get; set; }
        public void SetNow()
        {
            Timestamp = DateTime.Now;
        }
        
        [XmlAttribute]
        public virtual double TimeSpent { get; set; }
        public virtual void SetTimeSpent(double timeSpent)
        {
            TimeSpent = timeSpent;
        }
        
        [XmlIgnore]
        public virtual string Tags { get; set; }
        [XmlAttribute]
        public virtual string PlatformId { get; set; }
        [XmlAttribute]
        public virtual Guid PlatformUniqueId { get; set; }
        
        [XmlIgnore]
        // 20141211
        // public virtual ScriptBlock[] BeforeScenario { get; set; }
        public virtual ICodeBlock[] BeforeScenario { get; set; }
        [XmlIgnore]
        // 20141211
        // public virtual ScriptBlock[] AfterScenario { get; set; }
        public virtual ICodeBlock[] AfterScenario { get; set; }
        [XmlIgnore]
        public virtual object[] BeforeScenarioParameters { get; set; }
        [XmlIgnore]
        public virtual object[] AfterScenarioParameters { get; set; }
        
        public virtual int GetAll()
        {
            return Statistics.All;
        }
        
        public virtual int GetPassed()
        {
            return Statistics.Passed;
        }
        
        public virtual int GetFailed()
        {
            return Statistics.Failed;
        }
        
        public virtual int GetPassedButWithBadSmell()
        {
            return Statistics.PassedButWithBadSmell;
        }
        
        public virtual int GetNotTested()
        {
            return Statistics.NotTested;
        }
    }
}
