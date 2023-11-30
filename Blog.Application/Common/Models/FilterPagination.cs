namespace Blog.Application.Common.Models;

public class FilterPagination
{
    public uint BlogCount { get; set; } = 0;

    public uint PageSize { get; set; } = 10;

    public uint PageToken { get; set; } = 1;
}