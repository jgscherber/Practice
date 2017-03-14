package jacob.scherber.slidingtiles;

import java.io.File;

import javax.swing.filechooser.FileFilter;

public class ImageFileFilter extends FileFilter {

	@Override
	public boolean accept(File arg0) {
		
		String fileName = arg0.getName().toLowerCase(); // switch to lowercase for the extension check
		
		return ((fileName.endsWith(".jpg")
				|| fileName.endsWith(".png")
				|| fileName.endsWith(".gif"))
				|| arg0.isDirectory());
		// && !(arg0.isDirectory()) // hides them from view!
	}

	@Override
	public String getDescription() {
		// shows up in the drop down under the file name
		return "All image files: *.jpg, *.png, *.gif";
	}

}
