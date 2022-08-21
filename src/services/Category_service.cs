using loja_api.config_context;
using loja_api.domain;
using loja_api.domain.dto;


namespace src.services;

//  partial interface IContext_service
// {
//     public abstract void Save(Categoria param);
//     public abstract Categoria Get(int param);
//     public abstract void Update(Categoria param);
//     public abstract int Delete(int param);
// }
class Category_service //: IContext_service
{
   public Category_service(Context_app context)=>  Context = context;

   private readonly Context_app Context;

    public int inactivate_childs(Categoria categoria)//todo verificar metodo
    {
       
        //
        //
        // List<Produto> produtos = Context.Produto.Where(p => p.Categoria.Id == categoria.Id).ToList();
        //
        // produtos.ForEach(p => p.set_isActive(false));
        //  
        //     
        // Context.Update(produtos);
        // Context.SaveChanges();
        return 1;
    }
    public int Delete(int param)//todo verificar metodo
    {
        Categoria categoria = Get(param);

        if(categoria is null)
            return 0;
        
        
        Context.Categoria.Remove(categoria);
        Context.SaveChanges();
        return 1;
    }

    

    public Categoria Get(int param)
    {
        return Context.Categoria.Find(param);
    }

    public IQueryable<CategoriaDto> GetAll()
    {

       return Context.Categoria.Select(c => new CategoriaDto
       {
           is_active = c.is_active, Id = c.Id, Name = c.Name
           
       });
         
    }
    
    

    public void Save(Categoria param)
    {
        Context.Categoria.Add(param);
        Context.SaveChanges();
    }

    public void Update(Categoria param)
    {
       Context.Categoria.Update(param);
       Context.SaveChanges();
    }
}