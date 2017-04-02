package jacob.scherber.mycomponents;

import java.io.IOException;
import java.net.URL;

import javax.sound.sampled.AudioInputStream;
import javax.sound.sampled.AudioSystem;
import javax.sound.sampled.Clip;
import javax.sound.sampled.LineUnavailableException;
import javax.sound.sampled.UnsupportedAudioFileException;
import javax.swing.JOptionPane;

public class FileIO {
	
	public static Clip playClip(Object requestor, String fileName) {
		Clip clip = null;
		try{
			URL url = requestor.getClass().getResource(fileName);
			AudioInputStream audioInputStream = AudioSystem.getAudioInputStream(url);
			clip = AudioSystem.getClip();
			clip.open(audioInputStream);
			clip.start();	
		} catch(IOException e) {	
			String message = "File cannot be opened.";
			JOptionPane.showMessageDialog(null, message);
		} catch (UnsupportedAudioFileException e) { // must be .wav or .au
			String message = "File type is unsupported.";
			JOptionPane.showMessageDialog(null, message);
		} catch (LineUnavailableException e) {
			String message = "Resources are not available to open the file.";
			JOptionPane.showMessageDialog(null, message);
		}
		
		return clip;
	}
	
}
