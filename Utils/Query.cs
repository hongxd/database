using System.Linq.Dynamic.Core;
using System.Text;
using database.Dto;

namespace database.Utils;

public static class Query
{
    public static string[] defaultExcludeFields = { "Page", "PageSize" };

    /// <summary>
    ///     配置分页
    /// </summary>
    /// <param name="data">配置的数据</param>
    /// <param name="pageConfig">带有页数和偏移量的类（必须是已实例化的）</param>
    /// <typeparam name="T">DbSet的类型</typeparam>
    /// <returns>配置好的内容</returns>
    public static IQueryable<T> ConfigPaging<T>(this IQueryable<T> data, IPaginable pageConfig) where T : class
    {
        var page = pageConfig.Page;
        var pageSize = pageConfig.PageSize;
        if (page != null) data = data.Skip((int)((page - 1) * 10));
        if (pageSize != null) data = data.Take((int)pageSize);
        return data;
    }

    /// <summary>
    ///     对字符串进行模糊匹配
    /// </summary>
    /// <param name="data"></param>
    /// <param name="dict"></param>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    public static IQueryable<T> ConfigStringQuery<T>(this IQueryable<T> data, Dictionary<string, string?> dict)
        where T : class
    {
        StringBuilder exp = new();
        foreach (var (key, value) in dict)
            if (value is not null or "")
                exp.Append($"{key}.Contains(\"{value}\")&&");
        var len = exp.Length;
        // exp.Append($"EF.Functions.Like({key},\"{value}\")&&");
        if (len == 0) return data;
        exp.Remove(len - 2, 2);
        return data.Where(exp.ToString());
    }

    /// <summary>
    ///     对非字符串进行相等的精确匹配
    /// </summary>
    /// <param name="data"></param>
    /// <param name="name">数据库字段名称</param>
    /// <param name="value">传过来字段对应的值</param>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    public static IQueryable<T> ConfigEqualSingleQuery<T>(this IQueryable<T> data, string name, object? value)
        where T : class
    {
        return value == null ? data : data.Where($"{name}=={value}");
    }


    public static Dictionary<string, string> GenerateParametersDictionary<T>(T dto, string[]? excludeFields = null)
    {
        var properties = typeof(T).GetProperties();
        var parameters = new Dictionary<string, string>();
        excludeFields ??= defaultExcludeFields;

        foreach (var property in properties)
        {
            var propertyValue = property.GetValue(dto);

            if (propertyValue is null or "") continue;
            if (excludeFields != null && excludeFields.Contains(property.Name)) continue;
            if (propertyValue == property.Name) continue;
            if (parameters.ContainsKey(property.Name)) continue;
            parameters.Add(property.Name, propertyValue.ToString());
        }

        return parameters;
    }
}