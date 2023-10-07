using System;

using Skyline.DataMiner.Scripting;
using Skyline.Protocol.SimpleTableExtension;

/// <summary>
/// DataMiner QAction Class: Add or Update Row.
/// </summary>
public static class QAction
{
    /// <summary>
    /// The QAction entry point.
    /// </summary>
    /// <param name="protocol">Link with SLProtocol process.</param>
    public static void Run(SLProtocol protocol)
    {
        try
        {
            int trigger = protocol.GetTriggerParameter();

            if (trigger == Parameter.Write.addrow_20)
            {
                SimpleTableCommon.AddRow(protocol);
            }
            else
            {
                string key = Convert.ToString(protocol.GetParameter(Parameter.Write.updaterow_130));
                SimpleTableCommon.UpdateRow(protocol, key);
            }
        }
        catch (Exception ex)
        {
            protocol.Log(
                $"QA{protocol.QActionID}|{protocol.GetTriggerParameter()}|Run|Exception thrown:{Environment.NewLine}{ex}",
                LogType.Error,
                LogLevel.NoLogging);
        }
    }
}