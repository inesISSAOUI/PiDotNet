package entities;

import java.util.Set;

import javax.persistence.CascadeType;
import javax.persistence.Entity;
import javax.persistence.GeneratedValue;
import javax.persistence.GenerationType;
import javax.persistence.Id;
import javax.persistence.OneToMany;
import javax.persistence.OneToOne;
import javax.persistence.Table;

import com.fasterxml.jackson.annotation.JsonBackReference;
import com.fasterxml.jackson.annotation.JsonIdentityInfo;
import com.fasterxml.jackson.annotation.ObjectIdGenerators;

@Entity
@Table
@JsonIdentityInfo(
		  generator = ObjectIdGenerators.PropertyGenerator.class, 
		  property = "id")
public class Equipe {
	@Id
	@GeneratedValue( strategy = GenerationType.IDENTITY )
	int idEquipe;
	//@JsonBackReference(value="manager")
	@OneToOne(mappedBy="equipe")
	Manager manager;
	@JsonBackReference(value="employes")
	@OneToMany(cascade=CascadeType.ALL,mappedBy="equipe")
	Set<Employe> employes;
	
    	
	
	public Equipe(int id, Manager manager, Set<Employe> employes) {
		super();
		this.idEquipe = id;
		this.manager = manager;
		this.employes = employes;
	}
	public int getId() {
		return idEquipe;
	}
	public void setId(int id) {
		this.idEquipe = id;
	}
	public Manager getManager() {
		return manager;
	}
	public void setManager(Manager manager) {
		this.manager = manager;
	}
	public Set<Employe> getEmployes() {
		return employes;
	}
	public void setEmployes(Set<Employe> employes) {
		this.employes = employes;
	}
	
	

}
