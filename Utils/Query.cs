using System.Text;
using database.Dto;

namespace database.Utils;

public static class Query
{
    /// <summary>
    ///     配置分页
    /// </summary>
    /// <param name="data">配置的数据</param>
    /// <param name="pageConfig">带有页数和偏移量的类（必须是已实例化的）</param>
    /// <typeparam name="T">DbSet的类型</typeparam>
    /// <returns>配置好的内容</returns>
    public static IEnumerable<T> ConfigPaging<T>(IEnumerable<T> data, IPaginable pageConfig) where T : class
    {
        var page = pageConfig.Page;
        var pageSize = pageConfig.PageSize;
        return data.Skip((page - 1) * 10).Take(pageSize);
    }

    public static string ConfigQuery<T>(T query) where T : class
    {
        StringBuilder whereExp = new();
        var dict = GenerateParametersDictionary(query, new[] { "Page", "PageSize" });
        foreach (var (key, value) in dict) whereExp.Append($@"{key} like '%{value}%' and ");

        if (whereExp.Length != 0) whereExp.Insert(0, @" where ").Remove(whereExp.Length - 4, 3);
        return whereExp.ToString();
    }


    private static Dictionary<string, string> GenerateParametersDictionary<T>(T dto, string[]? excludeFields)
    {
        var properties = typeof(T).GetProperties();
        var parameters = new Dictionary<string, string>();

        foreach (var property in properties)
        {
            var propertyValue = property.GetValue(dto);

            if (propertyValue is null or "") continue;
            if (excludeFields != null && excludeFields.Contains(property.Name)) continue;
            if ((string)propertyValue == property.Name) continue;
            if (parameters.ContainsKey(property.Name)) continue;

            parameters.Add(property.Name, propertyValue.ToString());
        }

        return parameters;
    }
}