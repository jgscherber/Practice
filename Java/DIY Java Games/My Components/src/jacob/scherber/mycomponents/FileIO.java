package jacob.scherber.mycomponents;

import java.awt.image.BufferedImage;
import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStream;
import java.io.InputStreamReader;
import java.net.URL;
import java.util.ArrayList;

import javax.imageio.ImageIO;
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
			String message = "File cannot be opened: " + fileName;
			JOptionPane.showMessageDialog(null, message);
		} catch (UnsupportedAudioFileException e) { // must be .wav or .au
			String message = "File type is unsupported: " + fileName;
			JOptionPane.showMessageDialog(null, message);
		} catch (LineUnavailableException e) {
			String message = "Resources are not available to open the file: " + fileName;
			JOptionPane.showMessageDialog(null, message);
		}
		
		return clip;
	}
	
	public static BufferedImage readImageFile(Object requestor, String fileName) {
		BufferedImage image = null;
		try {
			// getClass() to get runtime class of object
			InputStream input = requestor.getClass().getResourceAsStream(fileName);
			if(input == null) {
				String message = "File not found: " + fileName;
				JOptionPane.showMessageDialog(null, message);
			} else {
				image = ImageIO.read(input);
			}
		} catch(IOException e) {
			String message = fileName + " could not be opened.";
			JOptionPane.showMessageDialog(null,message);
		}
		return image;
	}
	
	public static ArrayList<String> readTextFile(Object requestor, String fileName) {
		ArrayList<String> lines = new ArrayList<>();
		try{
			InputStream input = requestor.getClass().getResourceAsStream(fileName);
			BufferedReader in = new BufferedReader(new InputStreamReader(input));
			String line = in.readLine();
			while(line!=null) {
				lines.add(line);
				line = in.readLine();
			}
			in.close();
		} catch (NullPointerException e) {
			String message = fileName + " could not be found.";
			JOptionPane.showMessageDialog(null,message);
		} catch (IOException e) {
			String message = fileName + " could not be opened.";
			JOptionPane.showMessageDialog(null,message);
		}
		return lines;
	}
	
}
