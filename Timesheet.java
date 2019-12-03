package entities;

import java.io.Serializable;
import java.util.Set;

import javax.persistence.CascadeType;
import javax.persistence.Entity;
import javax.persistence.GeneratedValue;
import javax.persistence.GenerationType;
import javax.persistence.Id;
import javax.persistence.OneToMany;
import javax.persistence.Table;

import com.fasterxml.jackson.annotation.JsonBackReference;
import com.fasterxml.jackson.annotation.JsonIdentityInfo;
import com.fasterxml.jackson.annotation.JsonManagedReference;
import com.fasterxml.jackson.annotation.ObjectIdGenerators;

@Entity
@Table
@JsonIdentityInfo(
		  generator = ObjectIdGenerators.PropertyGenerator.class, 
		  property = "id")
public class Timesheet implements Serializable {
	/**
	 * 
	 */
	private static final long serialVersionUID = 1L;
	@Id
	@GeneratedValue( strategy = GenerationType.IDENTITY )
	int idTimesheet;
	String designation;
	@JsonBackReference(value="taches")
	@OneToMany(cascade=CascadeType.ALL,mappedBy="timesheet")
	Set<Tache> taches;
	@JsonBackReference(value="travailParJour")
	@OneToMany(cascade=CascadeType.ALL,mappedBy="timesheet")
	Set<TravailParJour> travailParJour;
	
	
	
	public Timesheet(String designation) {
		super();
		this.designation = designation;
	}

	public Timesheet(int id, String designation, Set<Tache> taches, Set<TravailParJour> travailParJour) {
		super();
		this.idTimesheet = id;
		this.designation = designation;
		this.taches = taches;
		this.travailParJour = travailParJour;
	}
	
	public Timesheet() {
		// TODO Auto-generated constructor stub
	}
	public int getId() {
		return idTimesheet;
	}
	public void setId(int id) {
		this.idTimesheet = id;
	}
	public String getDesignation() {
		return designation;
	}
	public void setDesignation(String designation) {
		this.designation = designation;
	}
	
	
	public Set<Tache> getTaches() {
		return taches;
	}

	public void setTaches(Set<Tache> taches) {
		this.taches = taches;
	}

	public Set<TravailParJour> getTravailParJour() {
		return travailParJour;
	}
	public void setTravailParJour(Set<TravailParJour> travailParJour) {
		this.travailParJour = travailParJour;
	}
	
	
	

}
