﻿/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 2/28/2014
 * Time: 1:10 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace UIAutomation
{
    extern alias UIANET; extern alias UIACOM;// using System.Windows.Automation;
    using classic = UIANET::System.Windows.Automation; using viacom = UIACOM::System.Windows.Automation; // using System.Windows.Automation;
    using System.Collections.Generic;

    /// <summary>
    /// Description of ControlFromUiaComProvider.
    /// </summary>
    [UiaSpecialBinding]
    public class ControlFromUiaComProvider : ControlProviderTemplate
    {
        public classic.Condition Condition { get; set; }
        public classic.TreeScope TreeScope { get; set; }
        
//        public override List<IUiElement> GetElements(ControlSearcherTemplateData data)
//        {
//            return new List<IUiElement>();
//        }
        
        internal override List<IUiElement> FilterElements(SingleControlSearcherData controlSearcherData, List<IUiElement> initialCollection)
        {
            return ResultCollection;
        }
        
        internal override List<IUiElement> LoadElements(SingleControlSearcherData controlSearcherData)
        {
            return ResultCollection;
        }
    }
}
