package entities;

import java.io.Serializable;
import java.util.Date;

import javax.persistence.Entity;
import javax.persistence.EnumType;
import javax.persistence.Enumerated;
import javax.persistence.GeneratedValue;
import javax.persistence.GenerationType;
import javax.persistence.Id;
import javax.persistence.ManyToOne;
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
public class Tache implements Serializable {
	/**
	 * 
	 */
	private static final long serialVersionUID = 1L;
	public static enum Etat{en_cours,achevée_à_temps,achevée_avant_temps_estimé,achvée_en_retard,en_suspension,en_arrêt};
	
	@Id
	@GeneratedValue( strategy = GenerationType.IDENTITY )
	int id;
	String nom;
	Date dateDeDebut;
	Double nombreDheuresEstimes;
	Etat etatActuel;
    
	
	
	public Tache() {
		super();
	}



	
	
	
	
	
	public Tache(int id, String nom, Date dateDeDebut, Double nombreDheuresEstimes, Etat etatActuel, int priorite,
			Timesheet timesheet) {
		super();
		this.id = id;
		this.nom = nom;
		this.dateDeDebut = dateDeDebut;
		this.nombreDheuresEstimes = nombreDheuresEstimes;
		this.etatActuel = etatActuel;
		this.priorite = priorite;
		this.timesheet = timesheet;
	}



	public Tache(int id, String nom, Date dateDeDebut, Double nombreDheuresEstimes, Etat etatActuel, int priorite,
			Employe employe, Timesheet timesheet) {
		super();
		this.id = id;
		this.nom = nom;
		this.dateDeDebut = dateDeDebut;
		this.nombreDheuresEstimes = nombreDheuresEstimes;
		this.etatActuel = etatActuel;
		this.priorite = priorite;
		this.employe = employe;
		this.timesheet = timesheet;
	}



	public Tache(String nom, Date dateDeDebut, Double nombreDheuresEstimes, Etat etatActuel, int priorite,
			Timesheet timesheet) {
		super();
		this.nom = nom;
		this.dateDeDebut = dateDeDebut;
		this.nombreDheuresEstimes = nombreDheuresEstimes;
		this.etatActuel = etatActuel;
		this.priorite = priorite;
		this.timesheet = timesheet;
	}
	int priorite;
	//@JsonManagedReference(value="idEmploye")
	@ManyToOne
	Employe employe;
	//@JsonManagedReference(value="idTimesheet")
	@ManyToOne
	Timesheet timesheet;
	
	public int getId() {
		return id;
	}
	public void setId(int id) {
		this.id = id;
	}
	public String getNom() {
		return nom;
	}
	public void setNom(String nom) {
		this.nom = nom;
	}
	public Date getDateDeDebut() {
		return dateDeDebut;
	}
	public void setDateDeDebut(Date dateDeDebut) {
		this.dateDeDebut = dateDeDebut;
	}
	public Double getNombreDheuresEstimes() {
		return nombreDheuresEstimes;
	}
	public void setNombreDheuresEstimes(Double nombreDheuresEstimes) {
		this.nombreDheuresEstimes = nombreDheuresEstimes;
	}
	
	@Enumerated(EnumType.STRING)
	public Etat getEtatActuel() {
		return etatActuel;
	}
	public void setEtatActuel(Etat etatActuel) {
		this.etatActuel = etatActuel;
	}
	public int getPriorite() {
		return priorite;
	}
	public void setPriorite(int priorite) {
		this.priorite = priorite;
	}
	public Employe getEmploye() {
		return employe;
	}
	public void setEmploye(Employe employe) {
		this.employe = employe;
	}
	public Timesheet getTimesheet() {
		return timesheet;
	}
	public void setTimesheet(Timesheet timesheet) {
		this.timesheet = timesheet;
	}
	
	

}
