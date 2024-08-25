Public Class AnimSpriteComponent
    Inherits SpriteComponent
    Sub New(ByRef owner As Actor, ByVal drawOrder As Integer)
        MyBase.New(owner, drawOrder)
        mCurrFrame = 0.0
        mAnimFPS = 5.0
        mAnimNumBeg = 0
        mAnimNumLast = 0
        mLoopFlag = False
    End Sub
    Public Overrides Sub Update(deltaTime As Double)
        If (mAnimTextures.Count > 0) Then
            mCurrFrame += mAnimFPS * deltaTime      '現在のフレームを更新する
            'ループさせないアニメーションが終わったら止める。
            If (mLoopFlag = False) Then
                If (mCurrFrame >= mAnimNumLast + 1) Then
                    mIsAnimating = False    'アニメーションが止まった
                    mCurrFrame = mAnimNumLast
                Else
                    mIsAnimating = True     'アニメーション中
                End If
            Else
                mIsAnimating = True     'ループアニメはアニメーション中とする。
                If (mCurrFrame >= mAnimNumLast + 1) Then
                    mCurrFrame = mAnimNumBeg        '必要に応じてカレントフレームを巻き戻す
                End If
            End If
            SetTexture(mAnimTextures(Int(mCurrFrame)))     '現時点でのテクスチャを設定する
        End If
    End Sub
    'アニメーションに使うテクスチャを設定する
    Public Sub SetAnimTextures(ByRef textures As List(Of Image))
        mAnimTextures = textures
        If (mAnimTextures.Count > 0) Then
            SetTexture(mAnimTextures(0))        '最初のフレームのテクスチャで初期設定
        End If
    End Sub
    'アニメーションに使うテクスチャの範囲を設定する。lastが-1なら全範囲とする。
    Public Sub SetAnimNum(ByVal beg As Integer, ByVal last As Integer, ByVal loop_flag As Boolean)
        If (last = -1) Then last = mAnimTextures.Count()
        mCurrFrame = Int(beg)
        mAnimNumBeg = beg
        mAnimNumLast = last
        mLoopFlag = loop_flag
    End Sub
    'アニメーションのフレームレートを設定／取得
    Public Function GetAnimFPS() As Double
        Return mAnimFPS
    End Function
    Public Sub SetAnimFPS(ByVal fps As Double)
        mAnimFPS = fps
    End Sub
    '現在表示中のアニメーションの情報取得
    Public Function GetAnimNumBeg() As Integer
        Return mAnimNumBeg
    End Function
    Public Function GetAnimNumLast() As Integer
        Return mAnimNumLast
    End Function
    Public Function GetAnimNumCurr() As Integer
        Return Int(mCurrFrame)
    End Function

    Private mAnimTextures As New List(Of Image)     'アニメーションでのすべてのテクスチャ
    Private mAnimNumBeg As Integer          'アニメーションの最初の配列番号
    Private mAnimNumLast As Integer         'アニメーションの最後の配列番号
    Private mCurrFrame As Double            '現在のフレーム
    Private mAnimFPS As Double          'アニメーションのフレームレート
    Private mLoopFlag As Boolean    'アニメーションをループさせるか
    Public mIsAnimating As Boolean      'アニメーション中かどうか
End Class
