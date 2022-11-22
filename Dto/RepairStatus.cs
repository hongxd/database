namespace database.Dto;

/// <summary>
/// 报修状态
/// </summary>
public static class RepairStatus
{
    /// <summary>
    /// 等待修复
    /// </summary>
    public static int Waiting = 0;
    /// <summary>
    /// 修复中
    /// </summary>
    public static int Repairing = 1;

    public static int Repaired = 2;
}