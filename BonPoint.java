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

@Entity
@Table
public class BonPoint implements Serializable {

    /**
	 * 
	 */
	private static final long serialVersionUID = 1L;
	public enum Recompense{Séjour,Prime,Cadeau}
	@Id
	@GeneratedValue( strategy = GenerationType.IDENTITY )
	int id;
	Recompense type;
	Date date;
	//@JsonBackReference(value="id")
	@ManyToOne
	Employe employe;
	
	
	
	public BonPoint(int id, Recompense type, Date date, Employe employe) {
		super();
		this.id = id;
		this.type = type;
		this.date = date;
		this.employe = employe;
	}
	public int getId() {
		return id;
	}
	public void setId(int id) {
		this.id = id;
	}
	@Enumerated(EnumType.STRING)
	public Recompense getType() {
		return type;
	}
	public void setType(Recompense type) {
		this.type = type;
	}
	public Date getDate() {
		return date;
	}
	public void setDate(Date date) {
		this.date = date;
	}
	public Employe getEmploye() {
		return employe;
	}
	public void setEmploye(Employe employe) {
		this.employe = employe;
	}
	
	
	
}
