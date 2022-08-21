using loja_api.config_context;
using loja_api.domain;

namespace src.services;

 class Produtc_service
{
    public Produtc_service(Context_app context)=>  Context = context;

   private readonly Context_app Context;

    public int Delete(int param)
    {
        Produto produto = Get(param);

        if(produto is null)
            return 0;
        else{
            Context.Produto.Remove(produto);
            Context.SaveChanges();
            return 1;
        } 
    }

    public Produto Get(int param)
    {
        return Context.Produto.Find(param);
    }

    public void Save(Produto param)
    {
        Context.Produto.Add(param);
        Context.SaveChanges();
    }

    public void Update(Produto param)
    {
       Context.Produto.Update(param);
       Context.SaveChanges();
    }
}