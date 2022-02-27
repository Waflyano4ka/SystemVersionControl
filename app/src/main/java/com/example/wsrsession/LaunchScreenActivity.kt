package com.example.wsrsession

import android.content.Intent
import android.os.Bundle
import android.os.Handler
import androidx.appcompat.app.AppCompatActivity

class LaunchScreenActivity: AppCompatActivity() {
    private val handler = Handler()
    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        setContentView(R.layout.launch_screen)
    }

    private val runnable = Runnable {
        if (!isFinishing) {
            val intent = Intent(this, MainActivity::class.java)
            startActivity(intent)

            finish()
        }
    }

    override fun onResume() {
        super.onResume()
        handler.postDelayed(runnable, 1000)
    }

    override fun onPause() {
        super.onPause()
        handler.removeCallbacks(runnable)
    }
}