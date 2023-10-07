using System;

using Skyline.DataMiner.Scripting;
using Skyline.Protocol.SimpleTableExtension;

/// <summary>
/// DataMiner QAction Class: QActionName.
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
            protocol.DeleteRow(Parameter.Simpletable.tablePid, protocol.RowKey());
            SimpleTableCommon.RefreshInfo(protocol);
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