using BobsBurgerAPI_v2.Infra.Data;
using System.Net;

namespace BobsBurgerAPI_v2.Endpoints.Situacoes;

public class SituacaoGetAll
{
    public static string Template => "/situacao";
    public static string[] Methods => new string[] { HttpMethod.Get.ToString() };
    public static Delegate Handle => Action;

    public class Resposta
    {
        public string contentType { get; set; }
        public string method { get; set; }
        public int statusCode { get; set; }
        public string statusDescription { get; set; }
        public string data { get; set; }
        public string hora { get; set; }
    }

    public static IResult Action(AppDbContext ctx)
    {
        //var situacoes = ctx.Situacoes.OrderByDescending(s => s.Id);        

        //return Results.Ok(situacoes);

        //var url = "http://transparencia.aracruz.es.gov.br/";
        //var url = "https://transparencia.serra.es.gov.br/";
        var url = "http://transparencia.vilavelha.es.gov.br/transparenciaWebCMVV/";

        var httpRequest = HttpWebRequest.Create(url);

        try
        {
            var httpResponse = (HttpWebResponse)httpRequest.GetResponse();
            Resposta res = new Resposta();
            res.contentType = httpResponse.ContentType;
            res.method = httpResponse.Method;
            res.statusCode = (int)httpResponse.StatusCode;
            res.statusDescription = httpResponse.StatusDescription;
            res.data = DateTime.Now.ToShortDateString();
            res.hora = DateTime.Now.TimeOfDay.ToString();

            //return Results.Ok(res);
            return Results.Ok(httpResponse);
        }
        catch
        {
            return Results.BadRequest("Sistema está offline!");
        }        
    }
}
