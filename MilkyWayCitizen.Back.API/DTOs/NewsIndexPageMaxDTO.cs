namespace MilkyWayCitizen.Back.API.DTOs
{
    public record NewsIndexPageMaxDTO
    (
        List<NewsIndexDTO> News,
        int PageMax
    );
}
