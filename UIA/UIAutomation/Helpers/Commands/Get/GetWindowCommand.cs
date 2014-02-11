﻿/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 2/11/2014
 * Time: 10:27 AM
 * 
 * To change cmdlet template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace UIAutomation.Helpers.Commands
{
    using System;
    using System.Management.Automation;
    using System.Collections;
    using System.Collections.Generic;
    using UIAutomation.Commands;
    
    /// <summary>
    /// Description of GetWindowCommand.
    /// </summary>
    public class GetWindowCommand : UiaCommand
    {
        public GetWindowCommand(CommonCmdletBase cmdlet) : base (cmdlet)
        {
        }
        
        public override void Execute()
        {
            var cmdlet =
                (GetUiaWindowCommand)Cmdlet;
            
            try {
            
            List<IUiElement> returnedWindows = new List<IUiElement>();
            
            try {

                if (null == cmdlet.ProcessName &&
                    (null == cmdlet.Name && null == cmdlet.AutomationId && null == cmdlet.Class) &&
                    null == cmdlet.ProcessId &&
                    null == cmdlet.InputObject) {
                    
                    cmdlet.WriteVerbose(
                        cmdlet, 
                        "no processName, name, processid or process was supplied");
                    
                    cmdlet.WriteError(
                        cmdlet,
                        "Neither ProcessName nor window Name are provided. Or ProcessId == 0",
                        "NoParametersInGetWindow",
                        ErrorCategory.InvalidArgument,
                        true);
                    
                } // describe
            } 
            catch (Exception eCheckParameters) {
                
                cmdlet.WriteVerbose(cmdlet, eCheckParameters.Message);

                cmdlet.WriteError(
                    cmdlet,
                    "Unknown error in '" + cmdlet.CmdletName(cmdlet) + "' ProcessRecord",
                    "UnknownInGetWindow",
                    ErrorCategory.InvalidResult,
                    true);
                
            } // describe
            
            try {
                
                var windowSearcher =
                    AutomationFactory.GetSearcherImpl<WindowSearcher>();
                
                var windowSearcherData =
                    new WindowSearcherData {
                    Win32 = cmdlet.Win32,
                    InputObject = cmdlet.InputObject,
                    ProcessNames = cmdlet.ProcessName,
                    ProcessIds = cmdlet.ProcessId,
                    Name = cmdlet.Name,
                    AutomationId = cmdlet.AutomationId,
                    Class = cmdlet.Class,
                    WithControl = cmdlet.WithControl,
                    TestMode = cmdlet.TestMode,
                    SearchCriteria = cmdlet.SearchCriteria,
                    First = cmdlet.First,
                    Recurse = cmdlet.Recurse,
                    WaitNoWindow = cmdlet.WaitNoWindow
                };
                
                returnedWindows =
                    windowSearcher.GetElements(
                        windowSearcherData,
                        cmdlet.Timeout);
                
                windowSearcherData = null;
            }
            catch {}
            
            try {
                if (null != returnedWindows && returnedWindows.Count > 0) {
                    
                    if (cmdlet.TestMode) {
                        
                        cmdlet.WriteObject(cmdlet, !cmdlet.WaitNoWindow);
                        
                    } else {
                        
                        cmdlet.WriteObject(cmdlet, returnedWindows);
                    }
                    
                    // 20140121
                    returnedWindows.Clear();
                    returnedWindows = null;
                    
                } else {
                    
                    if (cmdlet.TestMode) {
                        
                        cmdlet.WriteObject(cmdlet, cmdlet.WaitNoWindow);
                        
                    } else {
                    
                        string name = string.Empty;
                        string procName = string.Empty;
                        string procId = string.Empty;
        
                        try{ 
                            foreach(string n in cmdlet.Name) { 
                                name += n; name += ","; 
                            }
                            name = name.Substring(0, name.Length - 1);
                        }
                        catch {}
        
                        try{ 
                            foreach(string s in cmdlet.ProcessName) { 
                                procName += s; procName += ","; 
                            }
                            procName = procName.Substring(0, procName.Length - 1);
                        }
                        catch {}
        
                        try {
                            foreach (int i in cmdlet.ProcessId) {
                                procId += i.ToString();
                                procId += ",";
                            }
                            procId = procId.Substring(0, procId.Length - 1);
                        }
                        catch {}
        
                        cmdlet.WriteError(
                            cmdlet,
                            "Failed to get window in " + 
                            cmdlet.Timeout.ToString() +
                            " milliseconds by:" +
                            " process name: '" +
                            procName +
                            "', process Id: " + 
                            procId + 
                            ", window title: '" + 
                            name +
                            "', automationId: '" +
                            cmdlet.AutomationId +
                            "', className: '" +
                            cmdlet.Class +
                            "'.",
                            "FailedToGetWindow",
                            ErrorCategory.InvalidResult,
                            true);
                    }
                }
            }
            catch (Exception eOuter) {
                cmdlet.WriteVerbose(
                    cmdlet,
                    eOuter.Message);
            }
            
            }
            catch (Exception eTheOutest) {
                cmdlet.WriteVerbose(
                    cmdlet,
                    eTheOutest.Message);
            }
        }
    }
}
