package matchthree;

import javax.swing.*;
import jacob.scherber.mycomponents.*;

import java.awt.*;



public class MatchThree extends JFrame {

    private ScorePanel scorePanel = new ScorePanel(0, Color.GREEN);

    public MatchThree() {
        initGUI();
        setTitle("Match Three");
        setResizable(false);
        pack();
        setLocationRelativeTo(null);
        setVisible(true);
        setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
    }

    private void initGUI() {
        TitleLabel titleLabel = new TitleLabel("Match Three");
        add(titleLabel, BorderLayout.PAGE_START);
        // MAIN PANEL
        JPanel mainPanel = new JPanel();
        mainPanel.setBackground(Color.BLACK);
        mainPanel.setLayout(new BoxLayout(mainPanel, BoxLayout.Y_AXIS));
        add(mainPanel, BorderLayout.CENTER);
        // SCORE PANEL
        mainPanel.add(scorePanel);
        // BALL PANEL

        // BUTTON PANEL

    }

    public static void main(String[] args) {
        try {
            String className = UIManager.getCrossPlatformLookAndFeelClassName();
            UIManager.setLookAndFeel(className);
        } catch (Exception e) {}

        EventQueue.invokeLater(new Runnable() {
            @Override
            public void run() {
                new MatchThree();
            }
        });
    } // end main()
}
