/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package memento;

/**
 *
 * @author piotr_000
 */
public class Main {

    /**
     * @param args the command line arguments
     */
    public static void main(String[] args) {
        Originator originator = new Originator();
      CareTaker careTaker = new CareTaker();
      
      originator.setState("Stan #1");
      originator.setState("Stan #2");
      careTaker.add(originator.saveStateToMemento());
      
      originator.setState("Stan #3");
      careTaker.add(originator.saveStateToMemento());
      
      originator.setState("Stan #4");
      System.out.println("Obecny stan: " + originator.getState());		
      
      originator.getStateFromMemento(careTaker.get(0));
      System.out.println("Pierwszy stan: " + originator.getState());
      originator.getStateFromMemento(careTaker.get(1));
      System.out.println("Drugi stan: " + originator.getState());
    }
    
}
