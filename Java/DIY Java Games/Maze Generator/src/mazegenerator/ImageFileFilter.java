package mazegenerator;

import java.io.File;

import javax.swing.filechooser.FileFilter;

public class ImageFileFilter extends FileFilter {

	@Override
	public boolean accept(File arg0) {
		
		String fileName = arg0.getName().toLowerCase();
		
		return ((fileName.endsWith(".jpg")
				||
				|| )
				&& !());
		
	}

	@Override
	public String getDescription() {
		return "All image files: *.jpg, *.png, *.gif";
	}

}
