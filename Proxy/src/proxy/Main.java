/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package proxy;

/**
 *
 * @author piotr_000
 */
public class Main {

    /**
     * @param args the command line arguments
     */
    public static void main(String[] args) {
        
       Document doc = new ProxyDocument("test.txt");

      //image will be loaded from disk
      doc.display(); 
      System.out.println("");
      
      //image will not be loaded from disk
      doc.display(); 	
    }
    
}
