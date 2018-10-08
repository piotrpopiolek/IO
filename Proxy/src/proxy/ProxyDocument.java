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
public class ProxyDocument implements Document{

   private RealDocument realDocument;
   private String fileName;

   public ProxyDocument(String fileName){
      this.fileName = fileName;
   }

   @Override
   public void display() {
      if(realDocument == null){
         realDocument = new RealDocument(fileName);
      }
      realDocument.display();
   }
}
