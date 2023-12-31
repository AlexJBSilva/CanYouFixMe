using System;
using Skyline.DataMiner.Scripting;
using Skyline.Protocol.SimpleTableExtension;

/// <summary>
/// DataMiner QAction Class: After Startup.
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
            // Initializes the table with the first row, if empty.
            int rowsCount = protocol.RowCount(Parameter.Simpletable.tablePid);
            if (rowsCount == 0)
            {
                SimpleTableCommon.AddRow(protocol);
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
