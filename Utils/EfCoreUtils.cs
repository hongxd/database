namespace database.Utils;

public static class EfCoreUtils
{
    // 判断是否存在指定id的宿舍
    public static bool HaveDorm<T>(ApplicationDbContext ctx, Guid? id)
    {
        var dorm = ctx.Dormbuild.Where(db => db.Id == id);
        return dorm.Any();
    }
}