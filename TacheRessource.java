package webService;

import javax.ejb.EJB;
import javax.faces.bean.SessionScoped;
import javax.inject.Inject;
import javax.ws.rs.Consumes;
import javax.ws.rs.DELETE;
import javax.ws.rs.GET;
import javax.ws.rs.POST;
import javax.ws.rs.PUT;
import javax.ws.rs.Path;
import javax.ws.rs.PathParam;
import javax.ws.rs.Produces;
import javax.ws.rs.QueryParam;
import javax.ws.rs.core.MediaType;
import javax.ws.rs.core.Response;
import javax.ws.rs.core.Response.Status;


import entities.Tache;
import services.TacheService;

//NB !!!!!!!!!!!!!!!!!!!!!!!!!!!!! Quand je trouve pas l'entite, je dois retourner 404 not found pas 200 Ok

@Path("tache")
@javax.enterprise.context.RequestScoped
public class TacheRessource {
	@Inject
	TacheService tacheRessource=new TacheService();
	
	@POST
	@Consumes(MediaType.APPLICATION_JSON)
	public Response addTache(Tache bp)
	{
		if (tacheRessource.add(bp)) return Response.status(Status.OK).build();
		return Response.status(Status.NOT_FOUND).build();
	}
	
	@PUT
	@Consumes(MediaType.APPLICATION_JSON)
	public Response updateTache(Tache bp)
	{
		if (tacheRessource.update(bp)) return Response.status(Status.OK).build();
		return Response.status(Status.NOT_FOUND).build();
	}
	
	
	
	@GET
	@Produces(MediaType.APPLICATION_JSON)
	
	public Response getTache(@QueryParam(value = "id") Integer id)
	{   
		if (id!=null)  return Response.ok(tacheRessource.findById(id)).build();
		return Response.ok(tacheRessource.findAll()).build();
	}
	
	//Prochaine seance pidev (dernière séance de suivi (avant la validation) : consommation ws, implementation des services, génération des interfaces
	@DELETE
	@Path("{id}")
	public Response deleteTache(@PathParam(value = "id") int id)
	{   
		if  (tacheRessource.delete(id)) return Response.status(Status.OK).build();
		
		return Response.status(Status.NOT_FOUND).build();
	}

}
