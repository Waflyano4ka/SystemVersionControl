package com.example.wsrsession

import android.content.Intent
import android.media.Image
import android.os.Binder
import androidx.appcompat.app.AppCompatActivity
import android.os.Bundle
import android.util.Log
import android.widget.Button
import android.widget.EditText
import android.widget.ImageView
import android.widget.Toast
import androidx.activity.result.ActivityResultLauncher
import androidx.activity.result.contract.ActivityResultContracts
import androidx.core.app.AppLaunchChecker
import com.google.android.gms.auth.api.signin.GoogleSignIn
import com.google.android.gms.auth.api.signin.GoogleSignInClient
import com.google.android.gms.auth.api.signin.GoogleSignInOptions
import com.google.android.gms.common.SignInButton
import com.google.android.gms.common.api.ApiException
import com.google.firebase.auth.FirebaseAuth
import com.google.firebase.auth.GoogleAuthProvider
import com.google.firebase.auth.ktx.auth
import com.google.firebase.ktx.Firebase
import java.lang.Exception

class MainActivity : AppCompatActivity() {
    lateinit var launcher: ActivityResultLauncher<Intent>
    lateinit var auth: FirebaseAuth

    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        setContentView(R.layout.activity_main)

        auth = Firebase.auth
        launcher = registerForActivityResult(ActivityResultContracts.StartActivityForResult()) {
            val task = GoogleSignIn.getSignedInAccountFromIntent(it.data)
            try {

                val account = task.getResult(ApiException::class.java)
                if(account != null) {
                    firebaseAuthWithGoogle(account.idToken!!)
                }

            } catch (e: ApiException){
                Log.d("Error", e.message.toString())
            }
        }

        var GoogleSignIn = findViewById<ImageView>(R.id.GoogleSignIn)
        GoogleSignIn.setOnClickListener {
            SignInWithGoogle()
        }

        var SignUp = findViewById<Button>(R.id.SignUp)
        SignUp.setOnClickListener {
            val intent = Intent(this, MainActivity2::class.java)
            startActivity(intent)
        }

        var AuthLogin = findViewById<EditText>(R.id.AuthLogin)
        var AuthPassword = findViewById<EditText>(R.id.AuthPassword)

        var SignIn = findViewById<Button>(R.id.SignIn)
        SignIn.setOnClickListener {
            loginUsers(AuthLogin.text.toString(), AuthPassword.text.toString())
        }
    }

    private fun loginUsers(login: String, password: String) {
        auth.signInWithEmailAndPassword(login, password)
            .addOnCompleteListener(this){
                if (it.isSuccessful){
                    Toast.makeText(baseContext, "Успешно авторизирован", Toast.LENGTH_LONG).show()
                }
                else{
                    Toast.makeText(baseContext, "Ошибка", Toast.LENGTH_LONG).show()
                }
            }
    }

    private fun getClient(): GoogleSignInClient {
        val gso = GoogleSignInOptions
            .Builder(GoogleSignInOptions.DEFAULT_SIGN_IN)
            .requestIdToken(getString(R.string.default_web_client_id))
            .requestEmail()
            .build()

        return GoogleSignIn.getClient(this, gso)
    }

    private fun SignInWithGoogle() {
        val signInClient = getClient()
        launcher.launch(signInClient.signInIntent)
    }

    private fun firebaseAuthWithGoogle(idToken: String) {
        val credential = GoogleAuthProvider.getCredential(idToken, null)
        auth.signInWithCredential(credential).addOnCompleteListener {
            if(it.isSuccessful){
                Toast.makeText(baseContext, "Успешно" ,Toast.LENGTH_LONG).show()
            } else {
                Toast.makeText(baseContext, "Все сломалось" ,Toast.LENGTH_LONG).show()
            }
        }
    }
}